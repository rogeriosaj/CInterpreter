# CInterpreter - Interpretador da Linguagem C

## 📌 Visão Geral

O **CInterpreter** é um interpretador desenvolvido para processar programas escritos na linguagem **C**. Ele utiliza **ANTLR4** para análise léxica e sintática, seguido de um interpretador baseado em **C#** que executa o código interpretado.

O interpretador suporta diversas construções da linguagem **C**, incluindo **estruturas de controle, funções, entrada/saída, operadores e diretivas de pré-processamento**.

---

## 🚀 **Componentes Principais**

O interpretador é composto pelos seguintes módulos principais:

### 1️⃣ **Gramática ANTLR4 (********`ExprC.g4`********)**

- Define a sintaxe da linguagem **C** suportada pelo interpretador.
- Responsável por reconhecer **declarações de variáveis, expressões, controle de fluxo, funções e structs**.
- Utiliza **ANTLR4** para gerar o analisador léxico e sintático.

### 2️⃣ **Analisador Léxico e Sintático**

- Gerado automaticamente pelo **ANTLR4** a partir da gramática `ExprC.g4`.
- Converte o código fonte C em uma árvore de análise abstrata (AST).
- Permite que o **interpretador** percorra e execute o código corretamente.

### 3️⃣ **Interpretador (********`CInterpreterVisitor.cs`********)**

- Implementa a execução do código baseado na árvore sintática gerada pelo **ANTLR4**.
- Suporta **variáveis, operadores, controle de fluxo, structs e funções**.
- Mantém uma **memória de variáveis** para armazenar valores e atualizações.
- Gerencia **escopo de execução** para chamadas de função e estruturas de repetição.

### 4️⃣ **Script de Execução (********`denoro.sh`********)**

- Automação para compilar e executar o interpretador.
- Garante que o código-fonte **C** seja analisado e interpretado corretamente.

---

## 📌 **Características e Funcionalidades**

O **CInterpreter** implementa as seguintes funcionalidades da linguagem **C**:

### ✅ **1. Declaração e Inicialização de Variáveis**

- Suporte para **inteiros (********`int`********), caracteres (********`char`********), ponto flutuante (********`float`******** e ********`double`********)**.
- Suporte a **arrays e ponteiros (********`*`********)**.
- Verificação de **tipos e inicialização**.

✅ **Exemplo:**

```c
int a = 10;
char c = 'x';
double pi = 3.14;
```

---

### ✅ **2. Estruturas de Controle**

- **`if`**, **`if-else`**
- **`switch-case`**
- **`for`**, ****`while`****, **`do-while`**

✅ **Exemplo (********`if-else`********):**

```c
if (a > b) {
    printf("A é maior que B");
} else {
    printf("B é maior que A");
}
```

✅ **Exemplo (********`while`******** loop):**

```c
int a = 5;
while (a < 10) {
    printf("%d", a);
    a++;
}
```

✅ **Exemplo (********`switch-case`********):**

```c
switch(a) {
    case 1:
        printf("Caso 1");
        break;
    case 2:
        printf("Caso 2");
        break;
    default:
        printf("Nenhum caso");
}
```

---

### ✅ **3. Entrada e Saída (********`printf`********, ********`scanf`********)**

- Suporte para **exibição de valores (********`printf`********)**.
- Suporte básico para **entrada do usuário (********`scanf`********)**.

✅ **Exemplo (********`printf`********):**

```c
printf("O valor de a é %d", a);
```

✅ **Exemplo (********`scanf`********):**

```c
scanf("%d", &a);
```

---

### ✅ **4. Operadores**

- **Aritméticos (********`+`********, ********`-`********, ********`*`********, ********`/`********, ********`%`********)**
- **Lógicos (********`&&`********, ********`||`********, ********`!`********)**
- **Relacionais (********`==`********, ********`!=`********, ********`<`********, ********`>`********, ********`<=`********, ********`>=`********)**
- **Incremento/Decremento (********`++`********, ********`--`********)**

✅ **Exemplo:**

```c
int soma = a + b;
int produto = a * b;
(a > b)
(b < c);
```

---

### ✅ **5. Funções (com e sem retorno)**

- Suporte para **funções com e sem retorno**.
- Suporte para **passagem de parâmetros**.

✅ **Exemplo:**

```c
int soma(int a, int b) {
    return a + b;
}

int main() {
    int resultado = soma(5, 10);
    printf("Soma: %d", resultado);
    return 0;
}
```

---

### ✅ \*\*6. Suporte a ****`structs`**** e \*\***`unions`**

- Permite a criação de **estruturas complexas**.
- Suporta **acesso a membros (********`pessoa.codigo`********)**.

✅ **Exemplo (********`struct`********)**

```c
struct Pessoa {
    int codigo;
    int idade;
};

int main() {
    struct Pessoa pessoa;
    pessoa.codigo = 1;
    pessoa.idade = 20;
    printf("Código: %d, Idade: %d", pessoa.codigo, pessoa.idade);
    return 0;
}
```

---

### ✅ **7. Diretivas de Pré-Processamento (********`#include`********, ********`#define`********)**

- Reconhece **`#include <stdio.h>`**\*\* e outras bibliotecas.\*\*
- Suporte para **`#define`**\*\* macros\*\*.

✅ **Exemplo:**

```c
#define PI 3.14
printf("Valor de PI: %f", PI);
```

---

## 🛠 **Como Usar**

### **1️⃣ Compilar o Interpretador**

Execute o seguinte comando no terminal:

```bash
dotnet build
```

### **2️⃣ Executar um Programa C**

```bash
./denoro.sh arquivo.c
```

### **3️⃣ Exemplo de Saída**

```
Processando diretiva de pré-processamento: #include<stdio.h>
Variável declarada: int a = 10
A soma de 10 e 5 é 15
Retornando: 0
```

---

## 📌 **Conclusão**

O **CInterpreter** é um interpretador funcional que suporta diversas características da linguagem C, incluindo **variáveis, operadores, estruturas de controle, funções, structs e entrada/saída**.

✅ **Suporta uma ampla gama de recursos da linguagem C.**
✅ **Utiliza ANTLR4 para análise léxica e sintática.**
✅ **Implementado em C# para execução eficiente.**
✅ **Facilmente extensível para novas funcionalidades.**

**🎯 Próximos passos:**

- Melhorar suporte para `scanf`.
- Implementar suporte a **ponteiros e alocação dinâmica (********`malloc`********, ********`free`********)**.
- Adicionar **mais bibliotecas padrões (********`math.h`********, ********`string.h`********)**.

📌 **Desenvolvido por: [Seu Nome]**
