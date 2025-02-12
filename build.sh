#!/bin/bash
java -jar /usr/local/lib/antlr-4.13.2-complete.jar -Dlanguage=CSharp -visitor -listener -o Generated ./Grammar/C.g4

dotnet build

dotnet run -- ./hello.c
