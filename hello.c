#include <stdio.h>
#include <stdlib.h>  // Para atoi()

int main() {
    char nome[50];
    char idadeStr[10];  // Armazena a idade como string
    int idade;

    printf("Digite seu nome: ");
    gets(nome);

    printf("Digite sua idade: ");
    gets(idadeStr);  // Lê a idade como string

    idade = atoi(idadeStr);  // Converte string para inteiro

    printf("Nome: %s\n", nome);
    printf("Idade (convertida): %d\n", idade);

    return 0;
}
