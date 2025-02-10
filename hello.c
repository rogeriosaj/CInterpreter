#include <stdio.h>

int soma(int a, int b) {
    return a + b;
}

void printa() {
    printf("Hello, World!");
}

struct Pessoa {
    char nome[50];
    int idade;
};  

int main() {
    int a = 2;
    int b = 4;
    printf("A soma é: %d", soma(a, b));
    printa();

    struct Pessoa pessoa;
    pessoa.idade = 20;
    printf("Idade: %d", pessoa.idade);
    return 0;
}
