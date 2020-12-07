const crypto = require('crypto');
let authenticationToken;
crypto.randomBytes(16, (err, buf) => {
  if (err) throw err;
  console.log(`${buf.length} bytes of random data: ${buf.toString('hex')}`);
  authenticationToken = buff.ToString('base64');
});
