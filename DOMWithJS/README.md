https://www.youtube.com/watch?v=0dBY09OJm04

Esse sub arquivo é voltado a entender manipulação do DOM (Document Object Model) do Browser.

Esse conhecimento é bem util quando esta fazendo manipulações em paginas WEB...

Com HTML >> Pagina rudimentar
HTML + CSS >> Pagina Estática sem efeitos muito rebuscados
HTML + CSS + JS >> Da para fazer até o ula ula.

-----------//--------------------------//-----------------

Bom... No console de qualquer pagina WEB de um browser, voce consegue brincar :)

 - ´navigator´ é o objeto que aponta ao browser ao qual se esta utilizando
   - Pessoal usa esse objeto para detectar a plataforma em que esta rodando.
 - ´window´ ou ´Window´ mostra o objeto da tab... da tela onde se roda o javascript
 - ´document´ é o objeto que absorve o HTML e os demais arquivos carregados pelo window.
   - É essa criança que fornece ferramentas para manipulação dos objetos.
 - ´location´ objeto que representa o URL em que voce esta dentro
   - O mais util é o .pathname para capturar as rotas e o .href para capturar toda URL
 - ´history´ objeto que possibilita acesso ao historico


---------------//---------------------//----------------
 1. Seleção dos objetos pelos metodos:
        document.querySelector(''); //retorna o 1o objeto
            Dai voce acessa... como por exemplo o .exemplo para a classe exemplo, o #exemplo para o id exemplo e o exemplo puro para puxar o primeiro objeto com aquela tag
                ela retorna todo o objeto e todos seus parametros... inclusive o 'style'
                    Que retorna todas as possiveis caracteristicas (CSS)
        document.querySelectorAll('')
            Seleciona todos os elementos que utilizaram aquele call... retornando uma lista de objetos.
        Existem outras funçoes mais especificas, porem, querySelector e o querySelectorAll são os mais utilizados pois sao mais gerais.
    
 2. Depois de selecionado voce manipula o(s) elementos em si:
      .textContent --> É a propriedade que retorna o texto intra elementos
      .innerHTML --> Cria um novo objeto interno a este
      .addEventListener(Symbol,Callback) --> Setta um novo evento com base nos simbolos
          $ 'click' --> Usado para setar um evento de click no ambiente
          $ 'load' --> Usado para setar algo no carregamento... geralmente usado com objeto window.
          $ .setAttribute('alt','Nova propriedade do elemento, como por exemplo o alt')
          $ .forEach (CallBack) --> Para iterar pela lista resultante da selecao


---------// ------------// ----------------

