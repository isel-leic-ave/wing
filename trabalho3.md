# Enunciado do Trabalho 3

**Data limite de entrega: 31 de Maio**

**Objectivos:** Prática com Delegates, Genéricos e Iteradores _lazy_ (_yield generators_).

## Parte 1 --  `CsvParser` _lazy_

Remova da classe `CsvParser` todas as estruturas auxiliares com manutenção de
estado das linhas processadas (e.g. listas). O resultado do processamento das
linhas deverá ser sempre mantido na forma de uma instância de `IEnumerable`.
Repare que o tipo `String` também implementa `IEnumerable<Char>` pelo que deverá
eliminar a utilização do método `Split` e NÃO usar arrays auxiliares.

## Parte 2 --  Mocky, _delegates_ e genéricos

Adicione à API da biblioteca Mocky o método `Then(...)` que permite especificar
o comportamento de um método através de um _delegate_ conforme os exemplos
seguintes:

```csharp
Mocker mockCalc ...
...
mockCalc.When("Add").Then<int, int>(args => args[0] + args[1]);
...
Mocker mockReq = ...
...
mockReq.When("Dispose").Then(() => {/* do nothing */});
```

Note que o método `Then` pode ter várias sobrecargas consoante o tipo de
_delegates_ suportados.

A execução do método `Then` deve verificar se o tipo de delegate adicionado é
compatível com o descritor do método especificado. Em caso de incompatibilidade
lança excepção. A listagem seguinte apresenta alguns exemplos de utilização
incongruentes que devem dar excepção na execução do `Then`.

```csharp
mockCalc.When("Add").Then<int, double>(args => args[0] + args[1]);
...
mockReq.When("Dispose").Then<string>((arg) => {/* do nothing */});
```
