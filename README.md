
# GitHubApiStats

Simple API endpoint that calculates occurences of each of the letters in a chosen public Github repository and presents them in decreasing order.

As program uses Github API so please be mindful that there is a limit on number of calls an unauthenticated user can make. 
If you exceed this limit you will be informed by the program.



## API Reference

#### Gets statistics for chosen github repository

```http
  GET https://localhost:7290/statistics?owner={owner}&repository={repository}

```

| Parameter | Type     | Description                |
| :-------- | :------- | :------------------------- |
| `{owner}` | `string` | **Required**. Repository owner |
| `{repository}` | `string` | **Required**. Repository name |

Example of a call for a lodash repository:

https://localhost:7290/statistics?owner=lodash&repository=lodash



## Run Locally

Quickest way to run: 
- Clone the project,
- open in Visual Studio, 
- set GitHubAPIStats project as a start up project and run
- Swagger will open automatically

To run tests:
- set TestProject as a start up project and run tests
