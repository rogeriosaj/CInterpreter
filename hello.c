#include <stdio.h>

int main() {
    int mat[2][2];  // Declara uma matriz 2x2
    mat[0][1] = 5;  // Atribui um valor
    printf("%d\n", mat[0][1]); // Deve imprimir 5
    return 0;
}
