# AutoCheck .NET - Motor de Vistoria Veicular 🚗🏍️🚚

## O que o sistema faz e para que serve
O AutoCheck é uma aplicação de console desenvolvida em C# que simula o motor de processamento de vistorias técnicas de uma rede de concessionárias. Ele recebe a inspeção de Carros, Motos e Caminhões, aplica as regras específicas de cada categoria, calcula a pontuação de aproveitamento mecânico e emite um laudo determinando se o veículo está aprovado, aprovado com apontamentos ou reprovado.

## Como executá-lo
1. Certifique-se de ter o [.NET SDK](https://dotnet.microsoft.com/) instalado na sua máquina.
2. Clone este repositório: `git clone https://github.com/robertdcconsultor-web/T1.net-MiniProjeto.git`
3. Pelo terminal, navegue até a pasta do projeto executável:
   `cd src/AutoCheck.ConsoleApp`
4. Execute o comando:
   `dotnet run`

## Regra de cálculo e lógica adotada
Para evitar o uso de LINQ (conforme o requisito de aprendizado), toda a varredura de itens foi feita com laços `foreach`. A regra converte status de texto ("Bom", "Regular", "Ruim") em notas (10, 5, 0). O cálculo de aprovação faz o casting para `(double)` para garantir que a divisão entre inteiros gere o percentual correto sem truncar valores.

## Conceitos do Módulo 01 aplicados
- **Tipos e Variáveis:** Utilização de `string`, `int` e `double`.
- **POO Básica:** Criação das classes `ItemVistoria` e a classe abstrata `Veiculo`.
- **Encapsulamento e Construtores:** Uso de propriedades e a palavra-chave `this` para atribuição.
- **Herança e Polimorfismo:** Classes `Carro`, `Moto` e `Caminhao` herdando de `Veiculo` e usando `override` no método `ObterChecklistObrigatorio()`.

## Arquitetura Cliente-Servidor
Neste mini-projeto local, simulamos o conceito de cliente-servidor através da separação de responsabilidades. O `Program.cs` atua como o "Cliente" (Interface/Visão), coletando os dados do usuário, enquanto o `MotorVistoria.cs` atua como a lógica de "Servidor/Back-End", processando os dados e retornando o resultado processado sem se preocupar em como isso será exibido.

## Apresentação
🎥 [Link para o vídeo de demonstração no YouTube/Drive](#)