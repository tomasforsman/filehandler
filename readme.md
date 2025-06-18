# FileHandler

FileHandler is a set of microservices that allows Hantverksdata to send invoices through FTP using the connections between companies set in the PRI Web system.

It is used by having the service FileWatcher watch a folder and when there are new xml files in that folder it sends them to an Azure blob storage and notifies FileHandler.

[Documentation](Docs/readme.md)

## Prerequisites

Before you begin, ensure you have met the following requirements:

* Docker Compose is installed
* .Net Tye is installed
* Kubernetes for deployment

## Installing FileHandler

To install FileHandler and related services, follow these steps:

### Using Docker Compose
```bash
docker-compose up -d
```

### Using .NET Tye
```bash
tye run
```

### Using Kubernetes
Deploy the application using the provided Kubernetes manifests:
```bash
kubectl apply -f ./k8s/
```

## Using FileHandler

To use FileHandler, follow these steps:

### Starting the Services
1. Ensure all prerequisites are installed
2. Start the services using one of the installation methods above
3. FileWatcher will monitor the configured folder for new XML files
4. When files are detected, they are automatically uploaded to Azure blob storage
5. FileHandler processes the files and sends them via FTP based on PRI Web system configuration

### Configuration
Configure the application by updating the `appsettings.json` files in each service project.

### API Endpoints
The FileHandler API provides the following endpoints:
- `GET /FileInfo/{id}` - Get file information by ID
- `POST /FileInfo` - Submit new file information
- `PUT /FileInfo` - Update file information


## Contributors

Thanks to the following people who have contributed to this project:

* Tomas Forsman
* Martin Joabsson
* Jan Andersson

## Contact

If you want to contact me you can reach me at [tomas.forsman@prihandel.com](tomas.forsman@prihandel.com) or over Slack.

## License

This project uses the following license: [not set](#).