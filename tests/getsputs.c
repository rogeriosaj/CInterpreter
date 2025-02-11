#include <stdio.h>

int main() {
    char texto[100];

    printf("Digite algo: ");
    gets(texto); 

    printf("Você digitou: ");
    puts(texto);

    return 0;
}
