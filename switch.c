#include <stdio.h>

int main() {
    int a = 5;
    switch (a) {
        case 1: 
            printf("1");
            break;
        case 2:
            printf("2");
            break;
        case 3:
            printf("3");
            break;
        default:
            printf("Nenhum dos casos");    
    }
    return 0;
}