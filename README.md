# trams-data-api
Simple api for getting data from the TRAMS system



## Development Setup
### Setting up local trams database image
We use Github Container Registry to host our docker images.
You can sign into ghcr.io by following the guide [here](https://docs.github.com/en/packages/working-with-a-github-packages-registry/working-with-the-container-registry#authenticating-to-the-container-registry).

Once signed into ghcr.io you can pull down and run the `trams-development-database` image using:

`docker run -d -p 1433:1433 ghcr.io/dfe-digital/trams-development-database:latest`

You can connect to the MSSQL Server on port `1433`.
