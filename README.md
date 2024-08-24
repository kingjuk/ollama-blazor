# Ollama Blazor Server App


![alt text]([http://url/to/img.png](https://miro.medium.com/v2/resize:fit:1100/format:webp/1*loJZouS8KBmblH7GKziVUw.png))

## Overview

This project demonstrates how to set up an Ollama server on AWS with GPU support and integrate it with a .NET Blazor Server application. The Blazor app allows users to interact with AI models hosted on the Ollama server in real-time. The project is designed for offline usage by preloading models into the Docker container.

## Features

- **GPU-Enabled Ollama Server:** Utilizes GPU resources on AWS for enhanced AI performance.
- **Blazor Server Integration:** A .NET Blazor Server app that interacts with the Ollama API to provide a seamless AI chat experience.
- **Markdown Rendering:** User inputs and AI responses are rendered with advanced Markdown features.
- **Offline Model Support:** Preloads AI models into the Docker container to enable offline usage.

## Prerequisites

- **AWS Account:** An AWS account to create and manage GPU-enabled EC2 instances.
- **Docker & Docker Compose:** Installed on your local machine or the target server.
- **.NET 6.0 SDK:** Required to run the Blazor Server app.
- **Visual Studio:** (Optional) For development and debugging purposes.

## Getting Started

### 1. Set Up the Ollama Server on AWS

1. **Launch an EC2 Instance:**
   - Choose a GPU-enabled instance type (e.g., `g4dn.xlarge`).
   - Use an appropriate AMI (e.g., Ubuntu with GPU drivers).

2. **Install Docker and Docker Compose:**
   - SSH into your EC2 instance and install Docker:
     ```bash
     sudo apt-get update
     sudo apt-get install -y docker.io docker-compose
     ```

3. **Run the Ollama Server:**
   - Transfer the `docker-compose.yml` and custom `Dockerfile` to your EC2 instance.
   - Build the Docker image with preloaded models:
     ```bash
     docker build . ollama/ollama:latest .
     ```
   - Start the services:
     ```bash
     docker-compose up -d
     ```

### 2. Set Up the Blazor Server App

1. **Clone the Repository:**
   ```bash
   git clonehttps://github.com/kingjuk/ollama-blazor.git
   cd ollama-blazor-app
