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
x = Sinalt(np.array([3,4,3,2]), "Sinal x[n]", posInit=1)
x2 = ManipuladorSinalt.InvertSignal(x)
x2.name = "h[-k]"
x3 = ManipuladorSinalt.Desloca(x2,2)
x3.name = "h[-k+2]"
h = Sinalt(np.array([1,1,1,1,1]), "Sinal h[n]", posInit=2)
x4 = ManipuladorSinalt.MultiplicaSinais(x3,h)
x4.name = "x[k]*h[-k+2]"
c1 = ManipuladorSinalt.ConvSignal(h,x)
p1 = multiprocessing.Process(target=Plotter.PlotSigs,args = [x,h,c1],kwargs= {'substitle':"Operação Convolução entre dois sinais"})
p1.start()
p2 = multiprocessing.Process(target=Plotter.PlotSigs,args = [x,x2,x3,x4],kwargs= {'substitle':"Demonstração passo a passo convolucao"})
p2.start()

#---------------


#Join dos processos auxiliares:
p1.join()
p2.join()
