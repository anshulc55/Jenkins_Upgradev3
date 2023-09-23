#!/bin/bash
dotnet test --logger "trx;LogFileName=Pi.Math.trx" ./src/Pi.Math.Tests/Pi.Math.Tests.csproj
dotnet test --logger "trx;LogFileName=Pi.Runtime.trx" ./src/Pi.Runtime.Tests/Pi.Runtime.Tests.csproj