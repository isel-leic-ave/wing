# Enunciado do Trabalho 3

**Data limite de entrega: 31 de Maio**

**Objectivos:** Prática com Delegates, Genéricos e Iteradores _lazy_ (_yield generators_).

**Entregas:**
* Solução visual studio Wing completa com **todos os testes unitários** necessários
  à validação das funcionalidades pedidas.
* Wiki no repositório Github do grupo com explicação das principais decisões e opções
  tomadas na resolução dos requisitos do Trabalho 3. Exemplo de alguns aspectos
  (não limitados a estes):
  * Quais as estruturas de dados auxiliares que foram eliminadas do `CsvParser<T>`
    em substituição por sequências de tipo `IEnumerable<T>`.
  * Definição das assinaturas dos novos métodos `Then()` da API da biblioteca Mocky.
  * Quais as a estruturas alteradas ou adicionadas às classes da biblioteca Mocky.
  * Outros aspectos.


## Parte 1 --  `CsvParser` genérica e _lazy_

### Alínea A)

Torne a API de `CsvParser` genérica passando este tipo a ser `CsvParser<T>`.
Remova o parâmetro `klass` do seu construtor, passando este a ser determinado a
partir de `T`.
Por sua vez o método `Parse()` deixa de retornar `object[]` e passa a retornar
`T[]`.

### Alínea B)

Adicione a `CsvParser` um método `Parse(Func<string, T> parser)` em que a função
`parser` é a responsável por fazer o processamento da informação de cada linha e
instanciação do tipo `T`.

Nesta utilização NÃO é usada reflexão na instanciação de `T`. Mantenha em
funcionamento a possibilidade de utilização de um dos dois métodos:
`Parse()` ou `Parse(Func<string, T> parser)`.

Use este novo método `Parse(...)` para verificar num teste unitário que o
`parser` é executado de forma _eager_  no momento em que é chamado o
`Parse(...)`.

### Alínea C)

Remova da classe `CsvParser` todas as estruturas auxiliares com manutenção de
estado das linhas processadas (e.g. listas). O resultado do processamento das
linhas deverá ser sempre mantido na forma de uma instância de `IEnumerable`.
Repare que o tipo `String` também implementa `IEnumerable<Char>` pelo que deverá
eliminar a utilização do método `Split` e NÃO usar _arrays_ auxiliares.

Só poderá criar _arrays_ nos métodos `Parse`. 

Implemente um novo método `ToEnumerable(Func<string, T> parser)` que funciona em
alternativa ao `Parse` e que retorna uma instância  de `IEnumerable<T>` _lazy_.

Verifique num teste unitário que o `parser` de `ToEnumerable`é executado de
forma _lazy_ apenas no momento em que se itera sobre o resultado deste método.

## Parte 2 --  Mocky, _delegates_ e genéricos

Adicione à API da biblioteca Mocky o método `Then(...)` que permite especificar
o comportamento de um método através de um _delegate_ conforme os exemplos
seguintes:

```csharp
Mocker mockCalc ...
...
mockCalc.When("Add").Then<int, int, int>((a,b) => a + b);
...
Mocker mockReq = ...
...
mockReq.When("GetBody").Then<string, string>(url => ...);
mockReq.When("Dispose").Then(() => {/* do nothing */});
```

Note que o método `Then` pode ter várias sobrecargas consoante o tipo de
_delegates_ suportados.

A execução do método `Then` deve verificar se o tipo de delegate adicionado é
compatível com o descritor do método especificado. Em caso de incompatibilidade
lança excepção. A listagem seguinte apresenta alguns exemplos de utilização
incongruentes que devem dar excepção na execução do `Then`.

```csharp
mockCalc.When("Add").Then<int, int, double>((a, b) => a + b);
...
mockReq.When("Dispose").Then<string>((arg) => {/* do nothing */});
```
