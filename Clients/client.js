import fetch from 'node-fetch';

var query = `query{
    students{
      nodes{
        studentID
        groupID
        name
      }
    }
  }`;

 process.env.NODE_TLS_REJECT_UNAUTHORIZED = "0";

fetch('https://localhost:44371/api', {
        method: 'GET',
        headers: {
            'Content-Type': 'application/json',
            'Accept': 'application/json',
        },
        body: JSON.stringify({
            query
        })
    })
    .then(r => r.json())
    .then(data => console.log('data returned:', data['data']['students']));