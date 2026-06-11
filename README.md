\# Corredor do Medo VR



Projeto acadêmico desenvolvido em Unity para Android, usando Google Cardboard/VR mobile.



\## Proposta



Corredor do Medo VR é uma experiência curta de terror em realidade virtual. O jogador percorre um corredor escuro enquanto eventos de tensão são ativados conforme sua posição no cenário.



A proposta é criar medo usando iluminação, áudio espacial, objetos interativos, escurecimento de tela e um jumpscare final.



\## Plataforma



\* Unity

\* Android

\* Google Cardboard XR

\* Universal Render Pipeline / URP



\## Controles



\* Analógico esquerdo: movimentação do jogador

\* Movimento da cabeça / giroscópio: controle da câmera em VR

\* Outros botões: sem função nesta versão



\## Funcionamento do jogo



O jogo usa eventos baseados na posição Z do jogador dentro do corredor.



Sequência principal:



\* Z4: primeira luz pisca

\* Z7: som estranho inicial

\* Z12/Z13: batida na porta

\* Z14: caixa tomba

\* Z17: respiração atrás do jogador

\* Z22: Light\_03 muda para vermelho e pisca

\* Z24: passos atrás

\* Z28: arranhão na parede esquerda

\* Z35: jumpscare final

\* Após o jumpscare: tela escurece com Dark Overlay



\## Scripts principais



\* `VRAnalogMove`: movimentação manual pelo analógico esquerdo

\* `LightZoneByZ`: troca as luzes conforme o jogador avança

\* `ScareSoundByZ`: ativa sons em pontos específicos

\* `BoxTipByZ`: faz a caixa tombar

\* `RedLightFlickerByZ`: muda a Light\_03 para vermelho e faz a luz piscar

\* `JumpscareByZ`: ativa o jumpscare final e para o jogador

\* `DarkOverlayController`: escurece a tela no momento/final do susto



\## Organização do projeto



\* `\_Game/Scripts`: scripts criados para o jogo

\* `\_Game/Audio`: áudios do projeto

\* `\_Game/Materials`: materiais usados na cena

\* `\_Game/Textures`: texturas e imagens

\* `\_Game/Scenes`: cenas principais

\* `Assets/Samples`: arquivos do Google Cardboard XR Plugin



\## Como abrir o projeto



1\. Abrir o projeto pela Unity.

2\. Abrir a cena principal do corredor.

3\. Conferir se a plataforma está configurada para Android.

4\. Conectar um controle compatível para testar a movimentação manual.

5\. Executar a cena ou instalar o APK no celular Android.



\## APK



O APK final está disponível na aba Releases do repositório.



Nome sugerido do APK:



`Corredor\_do\_Medo\_VR\_Final.apk`



\## Créditos



Projeto desenvolvido para fins acadêmicos.



Ferramentas e tecnologias:



\* Unity

\* Universal Render Pipeline / URP

\* Google Cardboard XR Plugin



Demais créditos de assets, imagens e áudios estão no arquivo `CREDITOS.txt`.



