# BASICS

O conteudo basic mostra os conceitos minimos apresentados pela [Pagina Oficial](https://v4.webpack.js.org/concepts/)

## INTRODUÇÃO

O WEBPACK eh um JavaScript Bundler que consegue traduzir codigos NodeJS e seus modulos (voltados para CLIENT SIDE) em bundles Javascript puro minificados com o intuito de rodar **Aplicações WEB ESTATICAS**.
 - Maior Organização do codigo pois possibilita codar usando **MODULOS** (e ele depois reune tudo).
 - Acrescenta possibilidade de teste pois voce esta condando em NodeJS ao qual possui ferramentas voltadas a teste.
 - Reune tudo em poucos arquivos JS para inserção no HTML.
 - Conta com ferramentas FRONT ja implementadas no NodeJs ... Logo voce não precisa reinventar a roda.
 - Ele remove partes não utilizadas nas bibliotecas, otimizando a carga de JS (apesar de adicionar cargas adicionais voltadas a adaptações e polifits).
    - A otimização sem o WEBPACK eh superior, geralmente, porem o trade em tempo de desenvolvimento, facilidade de manutenção e a robustez do resultado final eh interessante.

## [SETUP INICIAL](https://v4.webpack.js.org/guides/getting-started/)

O WEBPACK eh um modulo NODE como todos os outros...

Inicia a gestão de pacotes pelo npm
~~~
npm init -y
~~~

Instala o webpack como dependencia de desenvolvimento
~~~
npm i -D webpack webpack-cli
~~~

No package.json adicione:
~~~
  "scripts": {
    "build": "webpack"
  },
~~~

Daqui pra frente existem diversas variações e formas distintas.

### webpack.config.js

Esse eh o arquivo de configuração do webpack.

## NESSE EXERCICIO:

Usamos o lodash module para inserir uma tag h1 no html. Também configuramos o babel-loader, css-loader e o style-loader