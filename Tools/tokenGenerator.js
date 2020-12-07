const axios = require('axios');
const https = require('https');
const crypto = require('crypto');
const { isNullOrUndefined } = require('util');
require('dotenv').config();
const TokenGenerator = {
    getToken() {

        const timestamp = (Date.now() / 1000 | 0).toString();
        const hash = crypto.createHash('sha256');

        const userNonce = 'FO#08052002';
        const userKey = '1d724b6fce43957f04913a0c455bd32264df5bbd450c9819fa4492c20a95c73d';
        const integrationIdentifier = ''; // leave empty for keys which do not specify an integration identifier

        const encrypted = hash.update(`${timestamp}${userKey}`).digest('hex');

        if (integrationIdentifier.length > 0) {
            // An integration identifier is specified
            const authToken = `${userNonce}:${timestamp}:${encrypted}:${integrationIdentifier}`;
            return authToken;
        }
        else {
            // An integration identifier is NOT specified
            const authToken = `${userNonce}:${timestamp}:${encrypted}`;
            return authToken;
        }
    }
};

const token = TokenGenerator.getToken();



const data = {
    "username": process.env.SITE_USER,
    "password": process.env.SITE_PASSWORD,
    "clientName": "DummyAPP",
    "authorizationToken": token,
    "siteName": process.env.SITE_NAME,

};

const url = process.env.API_URL + "/mt/api/rest/v1";


// At request level
const agent = new https.Agent({
    rejectUnauthorized: false
});



const getSessionId = () => {
    return new Promise((resolve, reject) => {
        console.log(data);
        axios.post(url + '/login', data, { httpsAgent: agent })
            .then(
                response => {
                    // http success, call the mutator and change something in state
                    resolve(response.data.result.session) // Let the calling function know that http is done. You may send some data back
                },
                error => {
                    // http failed, let the calling function know that action did not work out
                    reject(error)
                }
            )
    })
}







const getCamerasList = async (sessionId) => {


    return new Promise((resolve, reject) => {
        
        axios.get(url + '/cameras?session=' + sessionId, { httpsAgent: agent })
        .then(
                response => {
                    // http success, call the mutator and change something in state
                    resolve(response.data.result.cameras) // Let the calling function know that http is done. You may send some data back
                },
                error => {
                    // http failed, let the calling function know that action did not work out
                    reject(error)
                }
            )
    })

}


const geMediaStreamURL = () => {
    let sessionId = '';
    let cameraId = '';

    getSessionId().then(sId => 
        {
            sessionId = sId;
            console.log(sessionId);
            const cameras = getCamerasList(sessionId).then(cameras => {
                cameraId = cameras[0].id;
                console.log('session:',sessionId);
                console.log('camera:',cameraId);
                console.log(url + '/media?session='+sessionId+'&cameraId='+cameraId+'&format=fmp4&frames=all&media=video&t=live');
                
            })
        });
  

 

}

geMediaStreamURL();


