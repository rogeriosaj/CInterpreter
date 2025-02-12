#!/bin/bash
echo "Teste de operações aritméticas"
echo " "
dotnet run -- ./tests/math.c
echo " "
echo "------------------------------------------------------------------"
echo " "
echo "Teste de operações lógicas"
echo " "
dotnet run -- ./tests/switch.c
echo " "
echo " "
echo "------------------------------------------------------------------"
echo " "
dotnet run -- ./tests/if.c
echo " "
echo "------------------------------------------------------------------"
echo " "
echo "Teste de loops"
echo " "
dotnet run -- ./tests/while.c
echo " "
echo "------------------------------------------------------------------"
echo " "
dotnet run -- ./tests/dwhile.c
echo " "
echo "------------------------------------------------------------------"
echo " "
echo "Teste de funções"
echo " "
dotnet run -- ./tests/vfunc.c
echo " "
echo "------------------------------------------------------------------"
echo " "
echo "Teste de I/O"
echo " "
dotnet run -- ./tests/getsputs.c
echo " "
echo "------------------------------------------------------------------"
echo " "
dotnet run -- ./tests/scanf.c
echo " "
echo "------------------------------------------------------------------"
echo " "
echo "Teste de operadores "
echo " "
dotnet run -- ./tests/oplogicos.c
echo " "