#include <stdio.h>

int main() {
    int numeros[5];   // Declara um array de 5 elementos
    numeros[0] = 10;  // Atribui um valor ao primeiro elemento
    numeros[1] = 20;  // Atribui outro valor

    int x = numeros[0];  // Acessa um valor do array
    printf("%d", x);  // Deve imprimir 10

    return 0;
}