# Idealsoft-Code-Challenge
code test interview

BIBLIOTECAS UTILIZADAS: 

System.Net.Http.Json

Microsoft.EntityFrameworkCore

Microsoft.EntityFrameworkCore.InMemory

Microsoft.EntityFrameworkCore.Tools

Newtonsoft.Json

Swashbuckle.AspNetCore

<h1>
COMMENTS:
</h1>

(certifique-se de colocar ambos os projetos web api e WpfCrudApp como projetos de inicialização)

como nao foi especificado qual banco de dados utilizar, acredito que a melhor opção seria o banco de dados em memória, visto que a aplicação é somente um teste de código e não teria problema.

* não foi adicionado um molde de número de telefone (a string é livre)

* não foi adicionado validação de números duplicados

* erros e exceções controladas com try catch na API

* retorna sempre uma ApiResponse<T> criada para normalizar o output da api
