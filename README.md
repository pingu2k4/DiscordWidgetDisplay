# Discord Widget Display

## What is this?
This is a very simple WPF application I built to solve a problem. In voice chats, its not obvious who is talking. I wanted to solve that. There are things such as the Discord overlay, but this only works whilst in fullscreen games and I am in Discord voice chats when that solution won't work.
I looked for solutions, but didn't find anything that was perfect. The best I found was Discord StreamKit Overlay, and I set this up in OBS and projected the browser source to its own window. This wasn't transparent however, and took up more screen space than necessary. Plus running OBS all day isn't ideal.
I wanted to keep this minimal and maintain visible screen space.
It doesn't use MVVM and isn't super fancy, that wasn't the point with this. It really didn't need anything along those lines.

## What does it do?
I'm glad you asked! I actually went a little beyond what I initially set out to do, whilst sticking to the main goal.

- Displays who is talking in a transparent window in a voice chat you select
- Displays the last several lines of chat from a text chat you select
- Technically, will display any other website, however the size will be constrained to what is best for the Discord overlays
- Allows toggling the visibility of both the voice and text chat window. You can use either one, both, or none (though, why would you?)
- Allows easy toggling of the window being "always on top"
- Displays brief instructions in an about window
- Saves all your preferences (window location, voice / chat / on top toggles, browser addresses)

## Lets see it in action?
Sure! Here are both windows voice and chat sections toggled on. You can see that Pingu is talking, along with some voice chat above.
The voice chat is transparent, so what you can see behind is my desktop background.
![image](https://user-images.githubusercontent.com/11229848/147995550-f84c5630-52d0-4361-bc7b-57224e41e1a0.png)

When the text chat is hidden, you will only see the red bar (with less width than shown) and then people who chat.

## How do I get this?
There are two ways. Most users will want to download and run the installer, available on the [releases page](https://github.com/pingu2k4/DiscordWidgetDisplay/releases/). Alternatively, you can clone the repo and build it yourself. (If you don't know what this is, stick to the installer)

## How do I configure this?
Initially, you won't have anything showing. You will need to navigate to [Discord Streamkit](https://streamkit.discord.com/overlay). Here, you can setup a chat widget and a voice widget. (You will need to choose OBS or XSplit, either should be fine, and give access to the Streamkit app to your Discord).
Here, you can configure how your chat and voice widgets will display. Once you are happy, you can copy the URL from each widget, and paste into the corresponding address bars in the app. All visual options for the chat and voice panels are controlled via the streamkit URL you generate.
