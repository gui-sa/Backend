#!/usr/bin/env python3

#Imports:
import matplotlib.pyplot as plt
import numpy as np 
import multiprocessing
import math
import sys

class Sinalt:
    def __init__(self, arr:object, name:str, posInit = 0 ) -> object:
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
        Out.posInit -= tempo
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
        


#Instanciando os sinais do trabalho:
a = Sinalt(np.array([0,-2,0,1,2,1,0,3,2,0,0,-1]), "Sinal A", posInit=3)
b = Sinalt(np.array([1,0,1,0,3,-3,0,3,-1,2,2,0]), "Sinal B", posInit=3)
c = Sinalt(np.array([1,1,1,1,1,1,1]), "Sinal C", posInit=1)
d = Sinalt(np.array([1,1,1,1,2,2,2,0,2,2]), "Sinal D", posInit=2)
p1 = multiprocessing.Process(target=Plotter.PlotSigs,args = [a,b,c,d],kwargs= {'substitle':"Sinais originais"})
p1.start()
#---------------

#2.1 : a+b
Out1 = ManipuladorSinalt.SomaSinais(a,b)
p2 = multiprocessing.Process(target=Plotter.PlotSigs,args = [a,b,Out1],kwargs= {'substitle':"Soma Sinal A com Sinal B"})
p2.start()
#----------------

#2.2 : a+c
Out2 = ManipuladorSinalt.SomaSinais(a,c)
p3 = multiprocessing.Process(target=Plotter.PlotSigs,args = [a,c,Out2],kwargs= {'substitle':"Soma Sinal A com Sinal C"})
p3.start()
#----------------

#2.3 : c-d
Out3 = ManipuladorSinalt.SubtraiSinais(c,d)
p4 = multiprocessing.Process(target=Plotter.PlotSigs,args = [c,d,Out3],kwargs= {'substitle':"Subtraindo Sinal D de C"})
p4.start()
#----------------

#2.4 : b-a
Out4 = ManipuladorSinalt.SubtraiSinais(b,a)
p5 = multiprocessing.Process(target=Plotter.PlotSigs,args = [b,a,Out4],kwargs= {'substitle':"Subtraindo Sinal A de B"})
p5.start()
#----------------

#Teste Unitaria
Out7 = FuncToSinalt.Impulso(-2,2,1,1,0," ")
p8 = multiprocessing.Process(target=Plotter.PlotSigs,args = [Out7],kwargs= {'substitle':"Teste Impulso Unitario"})
p8.start()
#-------------


#3.1 : x1[n] = δ[n+2] + 2 δ[n] – 4 δ[n–3] + 3 δ[n–5] + 2 δ[n–6] , na faixa de –2 ≤ n ≤ 6.
Out5 = ManipuladorSinalt.SomaSinais(FuncToSinalt.Impulso(-2,6,1,1,2," "),FuncToSinalt.Impulso(-2,6,2,1,0," "),
    FuncToSinalt.Impulso(-2,6,-4,1,-3," "),FuncToSinalt.Impulso(-2,6,3,1,-5," "),FuncToSinalt.Impulso(-2,6,2,1,-6," "))
p6 = multiprocessing.Process(target=Plotter.PlotSigs,args = [Out5],kwargs= {'substitle':"Exercicio 3.1"})
p6.start()
#-------------


#Teste Degrau
Out8 = FuncToSinalt.Degrau(-2,2,1,1,0," ")
p9 = multiprocessing.Process(target=Plotter.PlotSigs,args = [Out8],kwargs= {'substitle':"Teste Degrau Unitario"})
p9.start()
#-------------

#3.2 : x2[n] = 2 u[n+4] – u[n–3] , na faixa de –7 ≤ n ≤ 7.
Out6 = ManipuladorSinalt.SubtraiSinais(FuncToSinalt.Degrau(-7,7,2,1,4," "),FuncToSinalt.Degrau(-7,7,1,1,-3," "))
p7 = multiprocessing.Process(target=Plotter.PlotSigs,args = [Out6],kwargs= {'substitle':"Exercicio 3.2"})
p7.start()
#----------------------

#4.1 : a(n – 4)
a2 = ManipuladorSinalt.Desloca(a,-4)
a2.name = "Sinal A deslocado"
p10 = multiprocessing.Process(target=Plotter.PlotSigs,args = [a,a2],kwargs= {'substitle':"Exercicio 4.1"})
p10.start()
#---------

#4.2 : b(n + 2)
b2 = ManipuladorSinalt.Desloca(b,2)
b2.name = "Sinal B deslocado"
p11 = multiprocessing.Process(target=Plotter.PlotSigs,args = [b,b2],kwargs= {'substitle':"Exercicio 4.2"})
p11.start()
#---------

#4.3 : c(n – 1)
c2 = ManipuladorSinalt.Desloca(c,-1)
c2.name = "Sinal C deslocado"
p12 = multiprocessing.Process(target=Plotter.PlotSigs,args = [c,c2],kwargs= {'substitle':"Exercicio 4.3"})
p12.start()
#---------

#4.4 : d(n + 3)
d2 = ManipuladorSinalt.Desloca(d,3)
d2.name = "Sinal D deslocado"
p13 = multiprocessing.Process(target=Plotter.PlotSigs,args = [d,d2],kwargs= {'substitle':"Exercicio 4.4"})
p13.start()
#---------

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
p11.join()
p12.join()
p13.join()