grammar C;

// Entrypoint
program : preprocessorDirective* (declaration | functionDeclaration)* mainFunction;

// Diretivas de pré-processamento
preprocessorDirective
    : '#' 'include' ('<' HEADER_FILE '>' | STRING_LITERAL)
    ;

// Função principal
mainFunction
    : 'int' 'main' '(' ')' block
    ;

// Declarações
declaration
    : variableDeclaration
    | statement
    | structDeclaration
    | unionDeclaration
    | returnStatement
    ;

// Declarações de função
functionDeclaration
    : type IDENTIFIER '(' (parameterList | ) ')' block
    ;

// Lista de parâmetros
parameterList
    : parameter (',' parameter)*
    ;

// Parâmetro
parameter
    : type IDENTIFIER
    ;

// Declaração de variável
variableDeclaration
    : type variableDeclarator (',' variableDeclarator)* ';'
    ;

// Declarador de variável
variableDeclarator
    : IDENTIFIER ('[' CONSTANT ']')* ('=' assignmentExpression)?
    | '*' IDENTIFIER ('[' CONSTANT ']')* ('=' assignmentExpression)?
    ;

// Declaração de struct
structDeclaration
    : 'struct' IDENTIFIER '{' structMember* '}' ';'
    ;

structInstance
    : 'struct' IDENTIFIER IDENTIFIER ';'   // Exemplo: struct Pessoa pessoa;
    ;

structAssignment
    : IDENTIFIER '.' IDENTIFIER '=' expression ';'  // Exemplo: pessoa.codigo = 1;
    ;

structMember
    : type IDENTIFIER ('[' CONSTANT ']')? ';'
    ;

// Declaração de union
unionDeclaration
    : 'union' IDENTIFIER '{' unionMember* '}' ';'
    ;

// Membros de union
unionMember
    : type IDENTIFIER ('[' CONSTANT ']')? ';'
    ;

// Bloco de código
block
    : '{' statement* '}'
    ;

// Instruções
statement
    : expressionStatement
    | blockStatement
    | ifStatement
    | returnStatement
    | variableDeclaration
    | forStatement
    | whileStatement
    | doWhileStatement
    | switchStatement
    | scanfStatement
    | printfStatement
    | functionCallStatement
    | pointerDeclaration
    | ternaryExpression
    | arrayDeclaration
    | matrixDeclaration
    ;

// Expressão de instrução
expressionStatement
    : expression ';'
    ;

// Instruções de printf
printfStatement
    : 'printf' '(' STRING_LITERAL (',' expression (',' expression)*)? ')' ';'
    ;

// Instruções de scanf
scanfStatement
    : 'scanf' '(' STRING_LITERAL (',' ('&'? IDENTIFIER))* ')' ';'
    ;

// Bloco de instruções
blockStatement
    : '{' statement* '}'
    ;

// Declaração if
ifStatement
    : 'if' '(' expression ')' statement ( 'else' statement )?
    ;

// Declaração switch
switchStatement
    : 'switch' '(' expression ')' '{' caseStatement* defaultStatement? '}'
    ;

caseStatement
    : 'case' CONSTANT ':' statement* 'break' ';'
    ;

defaultStatement
    : 'default' ':' statement*
    ;

forDeclaration
    : variableDeclaration
    | expression
    ;

// Declaração for
forStatement
    : 'for' '(' forControl ')' statement
    ;

forControl
    : (variableDeclaration | expression)? ';' expression? ';' (expression | unaryExpression)?
    ;

// Declaração while
whileStatement
    : 'while' '(' expression ')' statement
    ;

// Declaração do-while
doWhileStatement
    : 'do' statement 'while' '(' expression ')' ';'
    ;

// Chamada de função
functionCallStatement
    : IDENTIFIER '(' (expression (',' expression)*)? ')' ';'
    ;

// Declaração return
returnStatement
    : 'return' (expression)? ';'
    ;

selectionStatement
    : 'if' '(' expression ')' statement ('else' statement)?
    ;

// Declaração de ponteiro
pointerDeclaration
    : type '*' IDENTIFIER ('=' '&' IDENTIFIER)? ';'
    ;

// Expressões ternárias
ternaryExpression
    : logicalOrExpression '?' statement ':' statement
    ;

// Declaração de array    
arrayDeclaration
    : type IDENTIFIER '[' CONSTANT ']' ('=' '{' (expression (',' expression)*)? '}')? ';'
    ;

// Declaração de matriz
matrixDeclaration
    : type IDENTIFIER '[' CONSTANT ']' '[' CONSTANT ']' ('=' '{' (arrayInitializer (',' arrayInitializer)*)? '}')? ';'
    ;

arrayInitializer
    : '{' expression (',' expression)* '}'
    ;

// Tipos
type
    : 'int'
    | 'float'
    | 'void'
    | 'char'
    | 'double'
    | 'short'
    | 'long'
    | 'unsigned'
    | 'struct' IDENTIFIER
    ;

// Expressões de atribuição
assignmentExpression
    : IDENTIFIER '=' additiveExpression
    | additiveExpression
    ;

// Expressões
expression
    : logicalOrExpression
    ;

logicalOrExpression
    : logicalAndExpression ( '||' logicalAndExpression )*
    ;

logicalAndExpression
    : equalityExpression ( '&&' equalityExpression )*
    ;

equalityExpression
    : relationalExpression ( ( '==' | '!=' ) relationalExpression )*
    ;

relationalExpression
    : additiveExpression ( ( '<' | '>' | '<=' | '>=' ) additiveExpression)*
    ;

additiveExpression
    : multiplicativeExpression ( ( '+' | '-' ) multiplicativeExpression )*
    ;

multiplicativeExpression
    : unaryExpression ( ( '*' | '/' | '%' ) unaryExpression )*
    ;

unaryExpression
    : primaryExpression
    | unaryExpression ('++' | '--') 
    | ('++' | '--') unaryExpression 
    ;
primaryExpression
    : '(' expression ')'
    | IDENTIFIER ('.' IDENTIFIER)* ('[' expression ']')*
    | CONSTANT
    | STRING_LITERAL
    | 'sizeof' '(' type ')'
    ;

// Tokens
CONSTANT: INT | FLOAT | CHAR;
INT: [0-9]+;
FLOAT: [0-9]+ '.' [0-9]+;
CHAR: '\'' . '\'';
IDENTIFIER : [a-zA-Z_][a-zA-Z0-9_]*;
STRING_LITERAL : '"' (~["\\] | '\\' .)* '"';
HEADER_FILE : [a-zA-Z_][a-zA-Z0-9_]* '.' [a-zA-Z_][a-zA-Z0-9_]*;
WS : [ \t\r\n]+ -> skip;
COMMENT : '/*' .*? '*/' -> skip;
LINE_COMMENT : '//' ~[\r\n]* -> skip;
