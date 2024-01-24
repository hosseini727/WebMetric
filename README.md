## Overview
This project, built with .NET Core 7, focuses on analyzing advertisement events. Notably, swagger , our chosen library, eliminates the need for explicit inputs in its methods.
The checking process utilizes pre-existing information available in the program path, such as "impressions.json" and "click.json".

## Prerequisites
- .NET Core 7

## Usage
1. Clone the repository to your local machine.
2. Ensure you have .NET Core 7 installed.
3. Run the application.
   
## Input Data
The program reads and parses events from JSON files:
- **impressions.json**: Contains impression event data.
- **clicks.json**: Contains click event data.

  ## Metrics Calculation
The business metrics include:
- Count of impressions
- Count of clicks
- Sum of revenue
