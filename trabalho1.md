# Enunciado do Trabalho 1

**Data limite de entrega: 29 de Março**

## Parte 1

Pretende-se desenvolver uma biblioteca **Csvier** para processamento de dados em
formato CSV. Esta biblioteca disponibiliza uma classe `CsvParser` com a API
pública apresentada no diagrama seguinte:

<img src="assets/CsvParser.jpg" width="300px"/>

O exemplo seguinte demonstra um caso de utilização desta classe para
processamento de dados meteorológicos fornecidos pelo serviço [world weather
online](https://www.worldweatheronline.com/developer/api/docs/local-city-town-weather-api.aspx).

```csharp
string weatherJanuaryInLisbon = ...;
CsvParser pastWeather = new CsvParser(typeof(WeatherInfo))
                .CtorArg("date", 0)
                .CtorArg("tempC", 2)
                .PropArg("precipMM", 11)
                .PropArg("desc", 10);
object[] items = pastWeather
                    .Load(weatherJanuaryInLisbon)
                    .RemoveWith("#")
                    .Remove(1)
                    .RemoveEvenIndexes()
                    .Parse();
```

Pode obter os dados referentes ao exemplo anterior a partir do seguinte URL
substituindo `***` por uma chave que deve obter ao registar-se no serviço world
weather online:

http://api.worldweatheronline.com/premium/v1/past-weather.ashx?q=37.017,-7.933&date=2019-01-01&enddate=2019-01-30&tp=24&format=csv&key=**********************

Os métodos de `CsvParser` têm o seguinte comportamento:
* `CsvParser(Type klass, char separator)` – `klass` representa a classe alvo a
  instanciar e `separator` o carácter separador das colunas nos dados CSV. Este
  último é vírgula (`,`) por omissão.
* `CtorArg(string name, int col)` – associa o parâmetro `name` do construtor com a
  coluna de índice `col` dos dados CSV.
* `PropArg(string name, int col)` – associa a propriedade `name` com a coluna de
  índice `col` dos dados CSV.
* `FieldArg(string name, int col)` – associa o campo `name` com a coluna de índice
  `col` dos dados CSV.
* `Load(string data)` – lê e carrega os dados de `data` dividindo por linhas.
* `RemoveWith(string word)` – Remove todas as linhas que comecem com a string
  `word`.
* `Remove(int count)` – Remove um número de linhas iniciais igual `count`.
* `RemoveEvenIndexes()` – Remove as linhas de índice par (0, 2, 4,…)
* `RemoveOddIndexes()` – Remove as linhas de índice ímpar (1, 3, 5,…)
* `RemoveEmpties()` – Remove as linhas vazias, iguais a `“”`.
* `Parse():object[]` – Retorna um array com instâncias do tipo `klass`
  especificado no construtor. As instâncias são criadas a partir dos dados
  fornecidos no método `Load()`, usando o construtor que tem o tipo de parâmetros
  especificados no método `CtorArg` (pela respectiva ordem) e inicializando os
  campos e propriedades que foram especificados em `PropArg()` e `FieldArg()`.
  Assuma que os tipos de parâmetros do construtor, campos ou propriedades, têm
  sempre um método estático `Parse(string)`, que converte uma `string` num valor
  do respectivo tipo.

A biblioteca **Clima** disponibiliza a classe `WeatherWebApi` que permite
consultar as informações climáticas de _World Weather Online_ e pesquisar
localizações também a partir desta Web API. Para tal a classe `WeatherWebApi` usa
o `CsvParser` para processamento dos dados CSV e uma classe auxiliar `HttpRequest`
para realizar os pedidos HTTP à Web API.

<img src="assets/WeatherWebApi.jpg" width="700px">

A estrutura dos projectos **Csvier** e **Clima** é fornecida na solução Visual
Studio **Wing** disponível no github: https://github.com/isel-leic-ave/wing

1. Complete a implementação de `Csvier` realizando testes unitários que validem
   o seu correcto funcionamento.
2. Complete a implementação de `WeatherWebApi` de modo a passar os testes
   unitários de `ClimaTest`.

## Parte 2

Pretende-se que a correspondência entre os parâmetros do construtor, propriedades ou campos e as colunas dos dados CSV possa ser especificada nas classes por intermédio de _custom attributes_. 

Acrescente a **Csvier** esta capacidade especificando uma API baseada em custom_ attributes_ para este efeito.

Adicione os respectivos testes unitários.

## Parte 3

Crie um novo projecto com uma estrutura semelhante ao de **Clima** para ler dados CSV de um outro Feed ou Web API à sua escolha. Adicione os respectivos testes unitários.
