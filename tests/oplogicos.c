#include <stdio.h>

int main() {
    int a = 5;
    int b = 3; 
    int c = 0;

    printf("=== OPERADORES LÓGICOS ===");
    printf("!a = %d", !a);  // 0
    printf("!c = %d", !c);  // 1
    printf("a && b = %d", a && b);  // 1
    printf("a && c = %d", a && c);  // 0
    printf("a || b = %d", a || b);  // 1
    printf("a || c = %d", a || c);  // 1

    printf("=== OPERADORES RELACIONAIS ===");
    printf("a == b: %d", a == b);  // 0
    printf("a != b: %d", a != b);  // 1
    printf("a > b: %d", a > b);    // 1
    printf("a < b: %d", a < b);    // 0
    printf("a >= b: %d", a >= b);  // 1
    printf("a <= b: %d", a <= b);  // 0

    return 0;
}