import requests
import json

query = """query{
  students{
    nodes{
      studentID
      groupID
      name
    }
  }
}"""

query1 = """query AuthorVlad($name : String){
  students (where: {
    name: $name
  })
  {
    nodes {
      name
    }
  }
}
"""

variab = {
    "name": "Vlad"
}

url = 'https://localhost:44371/api'
reply = requests.post(url, json={'query': query1, 'variables': variab}, verify=False)

print("Status Code: {}".format(reply.status_code))
print(reply.text)
