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

como não foi especificado qual banco de dados utilizar, pensei que a melhor opção seria o banco de dados em memória, visto que a aplicação é apenas um teste de código.

como se trata de um banco de dados em memória, todos os dados são perdidos ao fechar a aplicação. por isso criei uma seed que insere dados fictícios no banco de dados (inMemoryDatabase) para simplificar a navegação na aplicação WPF.

a migração para um banco de dados sql não seria um trabalho, visto que as entidades e a estrutura do banco de dados foram criadas com o entity framework.

a respeito da aplicação wpf, tentei utilizar alguns frameworks para estilização (material design) mas todos pareciam estar descontinuados para essa versão do .net, então criei uma interface simples e sem muitos detalhes.

peço perdão pelos comentários bilíngues, alguns estão em português e outros em inglês.

* erros e exceções controladas com try catch na API

* retorna sempre uma ApiResponse<T> criada para normalizar o output da api
