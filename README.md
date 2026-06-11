# Corredor do Medo VR

Projeto acadêmico desenvolvido em **Unity** para **Android**, utilizando **Google Cardboard / VR mobile**.

---

## Sobre o projeto

**Corredor do Medo VR** é uma experiência curta de terror em realidade virtual.
O jogador percorre um corredor escuro enquanto eventos de tensão são ativados conforme sua posição dentro do cenário.

A proposta do jogo é criar medo usando:

* Iluminação dinâmica
* Áudio espacial
* Objetos interativos
* Escurecimento de tela
* Jumpscare final

---

## Download do APK

A versão final do APK está disponível na aba **Releases** deste repositório.

Arquivo:

```text
Corredor_do_Medo_VR_Final.apk
```

### Como testar

1. Baixe o APK pela aba **Releases**.
2. Instale em um celular Android.
3. Conecte um controle Bluetooth.
4. Use o analógico esquerdo para se movimentar.
5. Use o movimento da cabeça/giroscópio para controlar a câmera em VR.

---

## Plataforma

* Unity
* Android
* Google Cardboard XR
* Universal Render Pipeline / URP

---

## Controles

* **Analógico esquerdo:** movimentação do jogador
* **Movimento da cabeça / giroscópio:** controle da câmera em VR
* **Outros botões:** sem função nesta versão

---

## Funcionamento do jogo

O jogo utiliza eventos baseados na posição **Z** do jogador dentro do corredor.

Conforme o jogador avança, diferentes eventos são ativados para criar tensão e progressão de medo.

### Sequência principal de eventos

| Posição          | Evento                                |
| ---------------- | ------------------------------------- |
| Z4               | Primeira luz pisca                    |
| Z7               | Som estranho inicial                  |
| Z12 / Z13        | Batida na porta                       |
| Z14              | Caixa tomba                           |
| Z17              | Respiração atrás do jogador           |
| Z22              | `Light_03` muda para vermelho e pisca |
| Z24              | Passos atrás                          |
| Z28              | Arranhão na parede esquerda           |
| Z35              | Jumpscare final                       |
| Após o jumpscare | Tela escurece com o Dark Overlay      |

---

## Scripts principais

| Script                  | Função                                             |
| ----------------------- | -------------------------------------------------- |
| `VRAnalogMove`          | Movimentação manual pelo analógico esquerdo        |
| `LightZoneByZ`          | Troca as luzes conforme o jogador avança           |
| `ScareSoundByZ`         | Ativa sons em pontos específicos                   |
| `BoxTipByZ`             | Faz a caixa tombar                                 |
| `RedLightFlickerByZ`    | Muda a `Light_03` para vermelho e faz a luz piscar |
| `JumpscareByZ`          | Ativa o jumpscare final e para o jogador           |
| `DarkOverlayController` | Escurece a tela no momento/final do susto          |

---

## Organização do projeto

| Pasta             | Conteúdo                               |
| ----------------- | -------------------------------------- |
| `_Game/Scripts`   | Scripts criados para o jogo            |
| `_Game/Audio`     | Áudios do projeto                      |
| `_Game/Materials` | Materiais usados na cena               |
| `_Game/Textures`  | Texturas e imagens                     |
| `_Game/Scenes`    | Cenas principais                       |
| `Assets/Samples`  | Arquivos do Google Cardboard XR Plugin |

---

## Como abrir o projeto

1. Abrir o projeto pela Unity.
2. Abrir a cena principal do corredor.
3. Conferir se a plataforma está configurada para **Android**.
4. Conectar um controle compatível para testar a movimentação manual.
5. Executar a cena pela Unity ou instalar o APK em um celular Android.

---

## Build / APK

O APK final está disponível na aba **Releases** do repositório.

Nome do arquivo:

```text
Corredor_do_Medo_VR_Final.apk
```

---

## Créditos

Projeto desenvolvido para fins acadêmicos.

### Ferramentas e tecnologias

* Unity
* Universal Render Pipeline / URP
* Google Cardboard XR Plugin

Os demais créditos de assets, imagens, texturas e áudios estão disponíveis no arquivo:

```text
CREDITOS.txt
```


