<!DOCTYPE html>
<html>
	
<body>

<h1>Simple Calculator 1.0 Beta<br />
Short Instructions<br /></h1>

<a name="toc1"></a>
<h2>1. Introduction</h2>

<p>
This program is elementary desktop calculator for Windows written with C# language and Microsoft's "Windows Forms" technology. It's optimized for work with the screen readers JAWS and NVDA, which are the most used programs from people with sight problems. There are buttons with associated key combinations For every kind of number operation. The supported operations are:
</p>
<ul>
<li>Addition - Alt+A</li>
<li>Subtraction - Alt+S</li>
<li>Multiplication - Alt+M</li>
<li>Division - Alt+D</li>
<li>Calculating a percent value - Alt+P</li>
</ul>

<a name="toc2"></a>
<h2>2. License</h2>

<p>
 Simple Calculator is distributed under GNU General Public License version 3. More information can be found <A Href="https://github.com/stefantsvyatkov/simple-calculator/blob/master/LICENSE.md">here.</A>
</p>

<a name="toc3"></a>
<h2>3. Downloading</h2>

<p>
The present version of Simple Calculator can be downloaded from <A Href="https://github.com/stefantsvyatkov/simple-calculator/releases">here.</A>
</p>

<a name="toc4"></a>
<h2>4. System requirements</h2>

<ul>
<li>Windows 7 or newer</li>
<li>Microsoft .NET Framework 4.6.1<br />
 If this component is not installed and the program don't runs, it can be downloaded from <a href="https://download.microsoft.com/download/3/5/9/35980F81-60F4-4DE3-88FC-8F962B97253B/NDP461-KB3102438-Web.exe">here.</a>
</li>
</ul>

<a name="toc5"></a>
<h2>5. First start</h2>

<p>
In order to use this program, extract files from the archive "Simple Calculator 1.0 Beta.zip" and open "SimpleCalculator.exe". 
If the program is started for first time, it shows welcome message and window for choosing language. Supported languages at the moment are english and bulgarian. When "OK" button is pressed, the language is being saved and the main window is shown.
</p>
<p>
This initial setup is needed in first start or when the default settings of the program are reset.
</p>

<a name="toc6"></a>
<h2>6. Number operations</h2>

<p>
They can be made by using the corresponding buttons and/or entering of the operation signs in the number text box directly.
</p>

<a name="toc61"></a>
<h3>6.1. Calculating by the buttons</h3>

<p>
To make calculation, firstly enter a number and activate some of the buttons "Add", "Subtract", "Multiply", "Divide" or "Percent". This can be made by focusing the button and pressing Enter or the associated key combination. When some control (button or text box) is focused, the screen readers JAWS and NVDA report it's key shortcut.
</p>
<p>
After entering a number and choosing operation, the focus returns at the text box and second number must be entered. In the end activate the "Result" button.
</p>
<p><strong>
Example:
</p></strong>
<p>
To multiply 5 by 4,8, firstly enter 5, activate "Multiply" button, write 4,8 and press the "Result" button. It can be activated in 3 ways:
</p>
<ul>
<li>move to it with the TAB key and press Space</li>
<li>Enter key somewhere in the program</li>
<li>the combination Alt+R</li>
</ul>
<p>
After activating this button, the result of the calculation will be shown in the text box and copied to the clipboard automatically. It also can be operated with other numbers infinitely.
</p>
<p><strong>
Example:
</p></strong>
<p>
From some calculation the result is 3,1. We can multiply it by 10, after that to subtract 2 and so on. For every operation the "Result" button must be activated.
</p>

<a name="toc62"></a>
<h3>6.2. Calculating by entering the operation signs</h3>

<p>
The program allows entering the operation signs in the text box directly, without pressing of the corresponding buttons. These signs are:
</p>
<ul>
<li>+ - addition</li>
<li>- - subtraction</li>
<li>* - multiplication</li>
<li>/ - division</li>
<li>% - calculating a percent value</li>
</ul>
<p>
In order to make calculation in this way do the following:
</p>
<p>
Enter first number, operation sign and second number.
</p>
<p><strong>
Example:
</p></strong>
<p>
To multiply 5 by 3,8, write "5*3,8", press enter and the result is 20,14. If you want to operate it with other number, enter operation sign directly and the present result will be deleted. After that write second number and press Enter again. If there is a number before the operator, the calculator will make operation between the numbers to the left and right from the sign.
</p>

<a name="toc63"></a>
<h3>6.3. Calculating a percent value</h3>

<p>
It can be made by the following way:
</p>
<p>
Firstly enter the desired percent value, for example 20. Press the "Percent" button and write the number for which you want to calculate 20%, for example 200. If you press Enter, the result will be 40. The easier way is to write "20%200", press Enter and the result will be the above.
</p>

<a name="toc7"></a>
<h2>7. Context menu</h2>

<p>
The program has it's own context menu which can be activated by focusing some of the controls and pressing Applications key. It contains the following elements:
</p>
<ul>
<li>"Choose language" - shows window for choosing language. The confirmation can be made by activating "OK" button or pressing Enter.</li>
<li>"Open the help file" - according to the application's language opens the present file in English or Bulgarian.</li>
<li>"Reset default settings" - After activating this command, confirmation is required. If it's made, the calculator returns to the state before first start.</li>
<li>"Hide/Show operation buttons" - If the program is used mainly by entering the operation signs at the text box directly, the corresponding buttons can be hidden for easier use. When they are active the command is "Hide operation buttons", and in the reverse case it changes to "Show operation buttons".</li>
</ul>

<a name="toc71"></a>
<h3>7.1. Keyboard shortcuts</h3>

<ul>
<li>Ctrl+L - "Choose language"</li>
<li>Ctrl+H - "Open the help file"</li>
<li>Ctrl+R - "Reset default settings"</li>
<li>Ctrl+B - "Hide/Show operation buttons"</li>
</ul>

<a name="toc8"></a>
<h2>8. Report calling of some functions</h2>

<p>
After activating the "Result" button, the calculated value is announced by the screen readers JAWS and NVDA automatically.
</p>
<p>
If number operations are made with the key combinations of the buttons, after pressing them, the screen reader reports the corresponding action.
</p>
<p><strong>
Examples:
</p></strong>
<p>
For Alt+P, "Add" is announced, for Alt+S - "Subtract" and so on.
</p>
<p>
With showing and hiding the operation buttons by the combination Ctrl+B, the screen reader reports this with the messages "Buttons are hidden", "Buttons are shown".
</p>

<a name="toc9"></a>
<h2>9. Notes</h2>

<ul>
<li>When the program is used incorrectly, it shows error message which invite the user to make an operation or to enter a valid number.</li>
<li>Entering Intervals between numbers and operators is treated as invalid number (error message is shown and the text is deleted).</li>
<li>Expressions as 3+5*7 are not supported and are perceived as invalid numbers. If you want to make more calculations, activate "Result" button after every operation.</li>
<li>Pressing the "Clear" button returns the calculated number to it's default value, which is 0..</li>
<li>The program can be closed with the Esc key or the standard combination Alt+F4.</li>
</ul>

<a name="toc10"></a>
<h2>10. Contacts</h2>

<p>
For thoughts and suggestions about Simple Calculator, connect with me at <a href="mailto:stefcho.cvetkov@gmail.com">this</a> email.
</p>

</body>
	
</html>