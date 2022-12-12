#!/usr/bin/env python3

#Imports:
import matplotlib.pyplot as plt
import numpy as np 
import multiprocessing
import math
import sys

class Sinalt:
    def __init__(self, arr:object, name:str, posInit = 0 , escala=1) -> object:
        ''' Classe que cria um sinal.
            Cria um objeto Sinal no dominio do tempo
            arr: Objeto numpy Array onde o valor e a intensidade do sinal em cada [n] eh um passo homogenio no tempo
            posInit vale 0 por padrao o valor do primeiro [n]. Representa quantos [n] ele esta adiantado.
        '''
        #nao adianta somar os valores das intensidades do sinal ao longo de [n] se voce nao ter a referencia do inicio de [n]
        self.name = name
        self.intensity = arr
        self.posInit = -posInit
        self.len = len(arr)
        self.escala = escala
    

class FuncToSinalt:
    def __init__(self) -> object:
        ''' Classe que cria objetos do tipo Sinalt atraves de funcoes matematicas
        '''
        pass

    @staticmethod
    def  Impulso(init:int, end:int, amp:float, escala:float, deslocamento:int, name:str)->object:
        '''Recebe o intervalo de existencia do impulso... O intervalor em que ele sera representado
            init valor menor que end, em [n]
            end valor em [n] em que o sinal sera limitado [n]
            amp amplitude que o impulso unitario tera
            escala valor que multiplica [n]
            deslocamente: valor que soma o [n]
            name: nome que o sinal recebera
            retorna objeto do tipo Sinalt com essas caracteristicas

            eh obrigacao do programador ajustar os intervalos adequados dos sinais.
        '''
        end += 1 #Para ajustar o comprimento do vetor de tal forma que inclua o end.
        pulseIndexN = (-deslocamento)/(escala)
        pulse = amp*1
        sinalLen = end-init

        sinal = Sinalt(np.zeros(sinalLen),name,posInit=-init)

        j = 0
        for i in range(init,end,1):
            if i == pulseIndexN:
                sinal.intensity[j] = pulse
            j += 1

        return sinal

    @staticmethod
    def Degrau(init:int, end:int, amp:float, escala:float, deslocamento:int, name:str):
        '''Recebe o intervalo de existencia do Degrau... O intervalor em que ele sera representado
            init valor menor que end, em [n]
            end valor em [n] em que o sinal sera limitado [n]
            amp amplitude que o impulso unitario tera
            escala valor que multiplica [n]
            deslocamente: valor que soma o [n]
            name: nome que o sinal recebera
            retorna objeto do tipo Sinalt com essas caracteristicas

            eh obrigacao do programador ajustar os intervalos adequados dos sinais.
        '''
        end += 1 #Para ajustar o comprimento do vetor de tal forma que inclua o end.
        indexBegin = (-deslocamento)/(escala)
        pulse = amp*1
        sinalLen = end-init

        sinal = Sinalt(np.zeros(sinalLen),name,posInit=-init)

        j = 0
        if escala > 0:
            for i in range(init,end,1):
                if i >= indexBegin:
                    sinal.intensity[j] = pulse

                j += 1
        else:
            for i in range(init,end,1):
                if i <= indexBegin:
                    sinal.intensity[j] = pulse

                j += 1
        return sinal


class ManipuladorSinalt:
    def __init__(self):
        ''' Classe que Manipula Sinalt.
            Cria um objeto ManipuladorSinalt
            arr: Objeto numpy Array
        '''
        pass

    @staticmethod
    def SomaSinais (*args:object) -> object:
        ''' Recebe multiplos Sinal objects
            Retorna novo objeto Sinalt com a soma deles. 
        '''
        

        refMin = sys.maxsize
        refMax = -sys.maxsize
        refLen = 0

        for arg in args:
            if arg.posInit < refMin:
                refMin = arg.posInit
            temp = arg.posInit+arg.len
            if temp > refMax:
                refMax = temp
        refLen = int(refMax-refMin)

        Out = Sinalt(np.zeros(refLen),"Output",posInit= -refMin)

        ref = Out.posInit
        refPointer = 0
        refCounter = 0

        for _ in range(Out.len):
            for arg in args:
                if ref == arg.posInit:
                    #print(ref)
                    #print(refPointer)
                    refCounter = refPointer
                    for i in range(arg.len):
                        Out.intensity[refCounter] += arg.intensity[i]
                        refCounter += 1
                    
            ref += 1
            refPointer += 1

        
        return Out

    @staticmethod
    def SubtraiSinais (sig:object, sub:object) -> object:
        ''' Recebe um objeto Sinalt base sig e o que vai subtrar dele o sub 
            Retorna novo objeto Sinalt com a subtracao sig-sub. 
        '''
        temp = Sinalt(sub.intensity,sub.name, posInit= - sub.posInit)
        temp.intensity = -1*temp.intensity
        Out = ManipuladorSinalt.SomaSinais(sig,temp)
        
        return Out

    @staticmethod
    def NegaSinal (sig:object)-> object:
        '''Recebe um Sinalt 
           Retorna novo objeto Sinalt de com os sinais trocados
        '''
        Out = Sinalt(sig.intensity,sig.name, posInit= - sig.posInit)
        Out.intensity = -1*Out.intensity
        return Out

    @staticmethod
    def Desloca(sig:object ,tempo:int) -> object:
        ''' Desloca um Sinalt sig no tempo [n];
            tempo recebe um int e significa quantos blocos de tempo [n] o sinal se deslocou
            retorna nova instancia Sinalt deslocada no tempo
        '''
        Out = Sinalt(sig.intensity,sig.name, posInit= - sig.posInit)
        Out.posInit -= tempo*sig.escala
        return Out

    @staticmethod
    def ConvSignal (sig1:object, sig2:object)-> object:
        ''' Recebe um Sinalt
            sig 1 convoluirá sig 2
            Retorna novo objeto Sinalt
        '''
        limiteInferior = -1*(sig1.posInit + sig2.posInit)
        totalLen = sig1.len + sig2.len 
        Out = Sinalt(np.zeros(totalLen),f"Conv {sig1.name} com {sig2.name}", posInit= limiteInferior)
        
        ref = 0
        for n in range(Out.posInit, Out.posInit + Out.len):
            Out.intensity[ref] = ManipuladorSinalt.SubConv(sig1,sig2,n)
            ref += 1

        return Out
    

    @staticmethod
    def SubConv (estatico,dinamico,pos)-> object:
        ''' Recebe o x[k], o h[k] e o n desejado 
            Faz x[k]*h[-k+n]
            Retorna a soma da multiplicacao dos sinais de uma iteracao da convolucao
        '''
        Neg = ManipuladorSinalt.InvertSignal(dinamico)
        deslocado = ManipuladorSinalt.Desloca(Neg,pos)
        mult = ManipuladorSinalt.MultiplicaSinais(estatico,deslocado)
        soma = 0
        for i in range(mult.len):
            soma += mult.intensity[i]

        return soma 

    @staticmethod
    def InvertSignal (sig1:object)-> object:
        ''' Recebe um Sinalt
            e altera nega sua escala
            Retorna novo objeto Sinalt com a escala alterada
        '''
        novaPos = sig1.posInit + sig1.len - 1
        Out = Sinalt(np.zeros(sig1.len),f"Inverted {sig1.name}", posInit= novaPos, escala=-1*sig1.escala)
        for i in range(1,sig1.len+1):
            Out.intensity[i-1]=sig1.intensity[-i]
        
        return Out

    @staticmethod
    def MultiplicaSinais (sig1:object, sig2:object) -> object:
        ''' Recebe dois Sinalt objects
            Retorna novo objeto Sinalt com a multiplicacao deles. 
        '''

        if (sig1.posInit <= sig2.posInit):
            return  ManipuladorSinalt.Multiplica(sig1,sig2)
        else:
            return  ManipuladorSinalt.Multiplica(sig2,sig1)

                    
        

    @staticmethod
    def Multiplica(s1:object,s2:object) -> object:
        ''' Não utilize essa funcao diretamente.. Utilize a MultiplicaSinais
        '''
        Out = Sinalt(np.copy(s1.intensity),"Output", posInit= -s1.posInit, escala = s1.escala)

        for i in range(Out.len):
            if (Out.posInit+i) == s2.posInit:
                ref = i
                life = Out.len -1 - i
                for j in range(s2.len):
                    Out.intensity[ref] *= s2.intensity[j]
                    ref += 1
                    life -= 1
                    if(life<0):
                        break
                Out.intensity[ref :] = 0
                break
            Out.intensity[i] = 0
            

        return Out

class Plotter:
    def __init__(self) -> None:
        ''' Lidar com a plotagem de sinais.
        '''
        pass

    @staticmethod
    def PlotSigs(*args, substitle = ' ') -> None:
        '''Recebe multiplos objetos do tipo Sinal
            Gera um plot contendo todos os sinais em subplots
            subtitle eh opcional e eh o titulo do conjunto
            Nao retorna nada
        '''
        counter = 1
        for arg in args:
            plt.subplot(1,len(args),counter)
            plt.stem(np.linspace(arg.posInit,arg.posInit+arg.len-1,arg.len),arg.intensity)
            plt.grid()
            plt.ylabel(f"|{arg.name}|")
            plt.xlabel("[n]")
            plt.title(f"{arg.name}")
            counter += 1        
        plt.tight_layout(h_pad=1,w_pad=1)
        plt.subplots_adjust(top=0.85)
        plt.suptitle(f"{str(substitle)}")
        plt.show()
        


#Testando a convolucao passo a passo (por exemplo do caderno):
ex1 = Sinalt(np.array([3,4,3,2]), "Sinal h[n]", posInit=1)
ex2 = ManipuladorSinalt.InvertSignal(ex1)
ex2.name = "h[-k]"
ex3 = ManipuladorSinalt.Desloca(ex2,2)
ex3.name = "h[-k+2]"
eh1 = Sinalt(np.array([1,1,1,1,1]), "Sinal x[n]", posInit=2)
ex4 = ManipuladorSinalt.MultiplicaSinais(ex3,eh1)
ex4.name = "x[k]*h[-k+2]"
ec1 = ManipuladorSinalt.ConvSignal(eh1,ex1)
ec2 = ManipuladorSinalt.ConvSignal(ex1,eh1)
p1 = multiprocessing.Process(target=Plotter.PlotSigs,args = [ex1,eh1,ec1,ec2],kwargs= {'substitle':"Operação Convolução entre dois sinais"})
p1.start()
p2 = multiprocessing.Process(target=Plotter.PlotSigs,args = [eh1,ex1,ex2,ex3,ex4],kwargs= {'substitle':"Demonstração passo a passo convolucao"})
p2.start()

#---------------



#Exercicio 1:
x = Sinalt(np.array([11,7,0,-1,4]), "Sinal x[n]", posInit=3)
h = Sinalt(np.array([3,0,-5,2]), "Sinal h[n]", posInit=-2)
conv1 = ManipuladorSinalt.ConvSignal(x,h)
p3 = multiprocessing.Process(target=Plotter.PlotSigs,args = [x,h, conv1],kwargs= {'substitle':"Demonstração passo a passo convolucao"})
p3.start()

#-----------

#Exercicio 2a:
inicio = 0
fim = 15
Out1 = FuncToSinalt.Impulso(inicio,fim,0,1,-1," ")
for n in range(inicio,fim+1):
    novoPulso = FuncToSinalt.Impulso(inicio,fim,n*np.sin(n*np.pi/2),1,-n," ")
    Out1 = ManipuladorSinalt.SomaSinais(Out1,novoPulso)
Out1.name = "n*sen(n*pi/2)"
p4 = multiprocessing.Process(target=Plotter.PlotSigs,args = [Out1],kwargs= {'substitle':"Exercicio 2.a"})
p4.start()
#-----------


#Exercicio 2b:
inicio = 0
fim = 10
Out2 = FuncToSinalt.Impulso(inicio,fim,0,1,-1," ")
for n in range(inicio,fim+1):
    novoPulso = FuncToSinalt.Impulso(inicio,fim,3*(0.4**n),1,-n," ")
    Out2 = ManipuladorSinalt.SomaSinais(Out2,novoPulso)
Out2.name = "3*(0.4^n)*u(n)"
p5 = multiprocessing.Process(target=Plotter.PlotSigs,args = [Out2],kwargs= {'substitle':"Exercicio 2.b"})
p5.start()
#-----------


#Exercicio 2c:
inicio = 0
fim = 10
Out3 = FuncToSinalt.Impulso(inicio,fim,0,1,-1," ")
for n in range(inicio,fim+1):
    novoPulso = FuncToSinalt.Impulso(inicio,fim,n,1,-n," ")
    novoPulso2 = FuncToSinalt.Degrau(inicio,fim,1,1,-2, " ")
    pulsoRes = ManipuladorSinalt.MultiplicaSinais(novoPulso,novoPulso2)
    Out3 = ManipuladorSinalt.SomaSinais(Out3,pulsoRes)
novoPulso = FuncToSinalt.Impulso(inicio,fim,1,1,-4," ")
Out3 = ManipuladorSinalt.SomaSinais(Out3,novoPulso)
Out3.name = "n*u[n-2] + I[n-4]"
p6 = multiprocessing.Process(target=Plotter.PlotSigs,args = [Out3],kwargs= {'substitle':"Exercicio 2.c"})
p6.start()
#-----------

# Ex3 Comutatividade
com1 = ManipuladorSinalt.ConvSignal(Out1,Out2)
com2 = ManipuladorSinalt.ConvSignal(Out2,Out1)

p7 = multiprocessing.Process(target=Plotter.PlotSigs,args = [com1,com2],kwargs= {'substitle':"Exercicio 3 - Comutatividade"})
p7.start()
#------------------

# Ex3 Associatividade
com1 = ManipuladorSinalt.ConvSignal(Out1,Out2)
com1 = ManipuladorSinalt.ConvSignal(com1,Out3)
com2 = ManipuladorSinalt.ConvSignal(Out2,Out3)
com2 = ManipuladorSinalt.ConvSignal(Out1,com2)
p8 = multiprocessing.Process(target=Plotter.PlotSigs,args = [com1,com2],kwargs= {'substitle':"Exercicio 3 - Associatividade"})
p8.start()
#------------------

# Ex4 Distributividade
com1 = ManipuladorSinalt.ConvSignal(Out1,ManipuladorSinalt.SomaSinais(Out2,Out3))
com2 = ManipuladorSinalt.SomaSinais(ManipuladorSinalt.ConvSignal(Out1,Out2),ManipuladorSinalt.ConvSignal(Out1,Out3))
p9 = multiprocessing.Process(target=Plotter.PlotSigs,args = [com1,com2],kwargs= {'substitle':"Exercicio 3 - Distributividade"})
p9.start()
#------------------

# Ex4 Deslocamento
com1 = ManipuladorSinalt.ConvSignal(ManipuladorSinalt.Desloca(Out1,-3),ManipuladorSinalt.Desloca(Out2,-2))
com2 = ManipuladorSinalt.Desloca(ManipuladorSinalt.ConvSignal(Out1,Out2),-5)
p10 = multiprocessing.Process(target=Plotter.PlotSigs,args = [com1,com2],kwargs= {'substitle':"Exercicio 3 - Deslocamento"})
p10.start()
#------------------


#Join dos processos auxiliares:
p1.join()
p2.join()
p3.join()
p4.join()
p5.join()
p6.join()
p7.join()
p8.join()
p9.join()
p10.join()
