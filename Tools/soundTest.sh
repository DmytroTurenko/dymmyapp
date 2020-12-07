SESSION="AXsAhP8KEEuY8dygPUfQorIeZ1qgRv8SFgoUqV0RioBTnSPcOMOcXHxedaxPBzAaEFUU6t9YWUsginyN4QRlNX0iEPdOpZ5nh0uDlefhfThfDRsqCER1bW15QVBQMiEaEE2erIRywEb_v4iN8kVXy1cqDWFkbWluaXN0cmF0b3I"
CAMERA="49Ix0TNLTEszMTAw0DVMswQShknGuhaGJha6liaphonJRmYpiUlpesmJuQYGQgJTrj9qPPrfpb4xgTvpoFnpagA"
SERVER_URL="https://192.168.88.157:8443"
curl -k -X POST --header 'Content-Type: audio/pcmu' --header 'Accept: application/json' --data-binary @male.wav "${SERVER_URL}/mt/api/rest/v1/media?session=${SESSION}&cameraId=${CAMERA}&media=audio"