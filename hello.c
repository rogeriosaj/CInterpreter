#include <stdio.h>

void printMessage(int a, int b) {
    printf("Função sem retorno");
    printf("%d", a + b);
}

int main() {
    printMessage(5, 6); 
    return 0;
}