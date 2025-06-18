# FileHandler Documentation

## Architecture Overview

FileHandler is a microservices-based system for processing and distributing invoice files through FTP connections. The system consists of several components working together:

### Core Services

1. **FileWatcher** - Monitors folders for new XML files and uploads them to Azure blob storage
2. **FileHandler** - Main orchestration service that manages the file processing workflow
3. **FileReader** - Reads and validates file content
4. **FileSender** - Handles FTP transmission of files
5. **PriWebCommunicator** - Integrates with PRI Web system for communication settings

### Message Flow

1. FileWatcher detects new XML files in monitored folders
2. Files are uploaded to Azure blob storage
3. FileHandler receives notification and starts processing workflow
4. PriWebCommunicator retrieves FTP connection settings from PRI Web
5. FileReader validates the file content
6. FileSender transmits the file via FTP to the destination

### Configuration

Each service can be configured through `appsettings.json` files. Key configuration areas include:

- **MongoDB**: For state persistence
- **RabbitMQ**: For inter-service messaging
- **Application Insights**: For telemetry and monitoring
- **Queue Settings**: For message routing

### Development Setup

1. Install Docker Compose and .NET Tye
2. Clone the repository
3. Run `dotnet restore` to restore NuGet packages
4. Use `docker-compose up` or `tye run` to start all services
5. Configure connection strings and settings as needed

### API Documentation

The FileHandler API provides REST endpoints for managing file operations. XML documentation is included for all public APIs to support OpenAPI/Swagger generation.

### Testing

The system includes unit tests for core components. Tests focus on:
- Health check functionality
- Configuration validation
- Message consumer behavior
- State machine workflows

Run tests using `dotnet test` in the test project directories.
