#include <stdio.h>

struct Pessoa {
    int codigo;
    int idade;
};

int main() {
    struct Pessoa pessoa;  // Instância da struct
    pessoa.codigo = 1;
    pessoa.idade = 20;

    printf("Código: %d\n", pessoa.codigo);
    printf("Idade: %d\n", pessoa.idade);

    return 0;
}
