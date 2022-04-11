# FileHandler

FileHandler is a set of microservices that allows Hantverksdata to send invoices through FTP using the connections between companies set in the PRI Web system.

It is used by having the service FileWatcher watch a folder and when there are new xml files in that folder it sends them to an Azure blob storage and notifies FileHandler.

[Documentation](Docs/readme.md)

## Prerequisites

Before you begin, ensure you have met the following requirements:

* Docker Compose is installed
* .Net Tye is installed
* Kubernetes for deployment

## Installing <project_name>

To install FileHandler and related services, follow these steps:

Kubernetes:
```

```
<!--- Docker Compose and Tye usage --->

## Using <project_name>

To use FileHandler, follow these steps:

```

```
<!--- Commands and settings --->


## Contributors

Thanks to the following people who have contributed to this project:

* Tomas Forsman
* Martin Joabsson
* Jan Andersson

## Contact

If you want to contact me you can reach me at [tomas.forsman@prihandel.com](tomas.forsman@prihandel.com) or over Slack.

## License

This project uses the following license: [not set](#).