# Brevis-data-Manager
Projeto de manipulação de banco por classe

Visando atender meus clientes, identifiquei a necessidade de criar um procedimento padrão de acesso a banco, como meu foco é 
voltado inteiramente para a migração de sistemas Web, vi a necessidade de criar um gerenciador de bancos padrão que se adequasse a qualquer 
nomenclatura de banco e mesmo assim programar via classe.

Tenho por mim, que bancos de dados devem ser somente para armazenagem de dados, não para tratamento de regras ou qualquer outro fim, 
necessáriamente o sistema de classe, deve se apaptar ao banco e não o contrário.

Geração de banco por classe, ao meu ver é errado, pois a especialidade do banco seria gerar dependências e ou relações, assim como sua
chaves primárias e Extrarnas. Quero gerar tudo sem chave mesmo, tabelas flutuantes, beleza, só devemos saber que perderemos integridade 
de mais um ponto do sistema e é sabido que o dado armazenado em banco é o bem mais precioso de uma corporação seja ela qual for, e o 
sistema que o controla é apenas uma capa e deve sim permitir plugar a qualquer tipo de aplicação Web, Mobile ou Embarcado, no final 
das contas o unico capaz de garantir a funcionalidade das relações e integridade é o Banco de Dados.

O ganho de desenvolvimento por classe é real e muito antigo, este projeto tem a capacidade de interpretar conforme os nomes determinados
para as classes qual tabela e em que banco ele irá manipular (Insert, Update, Select e Delete), tudo isso baseado em scripts configuráveis
para determinados bancos.

O uso do VMBrevis é livre e aceita melhorias, só pesso que se houver melhorias, poste este para outras pessoas possam utilizalas e melhorar 
ainda mais o método.

A Vira Mundo é uma empresa particular, que visa colocar seu Pais no caminho da tecnológia web avançada, sem a utilização de servidores 
externos, com um fluxo de processamento e armazenagem compartilhada.
