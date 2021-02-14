using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour{

    public string name = "";
    public int orcamento = 65000;
    public int pontuacao = 0; 
    public int lampadas = 0;
    public int paineis = 0;
    public int sensores = 0;
    
    //*****Botões dos Menus*****//

    //*****Paineis*****//
    //Seleciona a opção de implementação 1 dos paineis solares
    public void OpcaoUmPaineis()
    {
        paineis = 1;
    }

    //Seleciona a opção de implementação 2 dos paineis solares
    public void OpcaoDoisPaineis()
    {
        paineis = 2;
    }

    //Seleciona a opção de implementação 3 dos paineis solares
    public void OpcaoTresPaineis()
    {
        paineis = 3;
    }

    //*****Lampadas*****//
    //Seleciona a opção de implementação 1 das Lampadas
    public void OpcaoUmLampadas()
    {
        lampadas = 1;
        //TODO Get da bd para popular as labels com a info das lampadas 1
    }

    //Seleciona a opção de implementação 2 das Lampadas
    public void OpcaoDoisLampadas()
    {
        lampadas = 2;
        //TODO Get da bd para popular as labels com a info das lampadas 2
    }

    //Seleciona a opção de implementação 3 das Lampadas
    public void OpcaoTresLampadas()
    {
        lampadas = 3;
        //TODO Get da bd para popular as labels com a info das lampadas 3
    }

    //*****Sensores*****//
    //Seleciona a opção de implementação 1 dos paineis solares
    public void OpcaoUmSensores()
    {
        sensores = 1;
        //TODO Get da bd para popular as labels com a info dos sensores 1
    }

    //Seleciona a opção de implementação 2 dos paineis solares
    public void OpcaoDoisSensores()
    {
        sensores = 2;
        //TODO Get da bd para popular as labels com a info dos sensores 2
    }

    //*****Confirmar Implementações*****//

    //*****Paineis*****//

    //Confirma a opção de paineis selecionada e faz aparecer paineis
    public void ImplementarPainel()
    {
        if (paineis == 1)
        {
            //TODO Fazer aparecer sem texturas o objeto no(s) sitio(s)
        }
        else if (paineis == 2)
        {
            //TODO Fazer aparecer sem texturas o objeto no(s) sitio(s)
        }
        else if (paineis == 3)
        {
            //TODO Fazer aparecer sem texturas o objeto no(s) sitio(s)
        }
    }

    //*****Lampadas*****//

    //Confirma a opção de lampadas selecionada e faz aparecer lampadas
    public void ImplementarLampadas()
    {
        if (lampadas == 1)
        {
            //TODO Fazer aparecer sem texturas o objeto no(s) sitio(s)
        }
        else if (lampadas == 2)
        {
            //TODO Fazer aparecer sem texturas o objeto no(s) sitio(s)
        }
        else if (lampadas == 3)
        {
            //TODO Fazer aparecer sem texturas o objeto no(s) sitio(s)
        }
    }

    //*****Sensores*****//

    //Confirma a opção de sensores selecionada e faz aparecer os sensores
    public void ImplementarSensores()
    {
        if (sensores == 1)
        {
            //TODO Fazer aparecer sem texturas o objeto no(s) sitio(s)
        }
        else if (sensores == 2)
        {
            //TODO Fazer aparecer sem texturas o objeto no(s) sitio(s)
        }
    }


    //*****Terminar Implementação*****//

    //*****Paineis*****//
    //Constroi os Paineis
    public void ConstruirPainel()
    {
        //TODO Ao clicar no local para implementar fazer aparecer as texturas do objeto

        if(paineis != 0 && lampadas != 0 && sensores != 0)
        {
            AcabarJogo();
        }
    }

    //*****Lampadas*****//
    //Constroi as Lampadas
    public void ConstruirLampadas()
    {
        //TODO Ao clicar no local para implementar fazer aparecer as texturas do objeto

        if (paineis != 0 && lampadas != 0 && sensores != 0)
        {
            AcabarJogo();
        }
    }

    //*****Sensores*****//
    //Constroi as Lampadas
    public void ConstruirSensores()
    {
        //TODO Ao clicar no local para implementar fazer aparecer as texturas do objeto

        if (paineis!= 0 && lampadas != 0 && sensores != 0)
        {
            AcabarJogo();
        }
    }


    //Termina o jogo e pede o nome ao jogador enquanto mostra um resumo do que fez
    public void AcabarJogo()
    {
        //TODO Mostrar o resumo ao jogador consoante o que escolheu (Ir buscar á BD consoante os IDS)
        //TODO Pedir o Nome do jogador (Meter Input com texto debaixo)
        //TODO Inserir Tudo na BD (Correr Script para adicionar tudo á tabela)
        //TODO Voltar para o MENU Principal (Trocar a scene para 0)
        name = "";
        lampadas = 0;
        paineis = 0;
        sensores = 0;

    }

}
   
   