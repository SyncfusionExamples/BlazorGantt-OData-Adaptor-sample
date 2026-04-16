# BlazorGantt OData Adaptor Sample

This repository contains a sample application that demonstrates how to retrieve data from a RESTful service and bind it to the Syncfusion Blazor Gantt Chart using the [ODataV4Adaptor](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.ODataV4Adaptor.html) of [SfDataManager](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.SfDataManager.html) component. The sample also illustrates how CRUD operations are performed through an [OData V4 service](https://docs.oasis-open.org/odata/odata/v4.0/errata03/os/complete/part1-protocol/odata-v4.0-errata03-os-part1-protocol-complete.html#_Toc453752197).

## Project Overview

The Syncfusion Blazor Gantt Chart supports remote data binding through RESTful services that follow the OData V4 specification. This project showcases how task data can be fetched from an OData service and rendered in the Gantt timeline using the ODataV4Adaptor. The SfDataManager acts as the communication layer between the Gantt component and the service endpoint.

The sample highlights how create, read, update, and delete operations initiated from the Gantt Chart are translated into OData requests and processed by the service. This approach enables standardized data access over HTTP and is suitable for applications that rely on OData‑based back-end services.

## Features

- Binding Gantt Chart data using `OData V4 services`
- Integration with RESTful services through SfDataManager
- Support for create, update, and delete operations
- Structured data communication using `ODataV4Adaptor`
- Implementation using Syncfusion Blazor Gantt components

## Configuration Notes

Before running the sample, ensure that the path of the `OData.mdf` file is correctly updated in the `appsettings.json` file of the OData adaptor project. The database file path must reference a valid local location.

## Prerequisites

- Visual Studio 2026
- .NET SDK compatible with Blazor
- Syncfusion Blazor Gantt NuGet package
- OData V4–compatible REST service

## Reference

For additional details, refer to the documentation:  
https://blazor.syncfusion.com/documentation/gantt-chart/data-binding#odatav4-adaptor
