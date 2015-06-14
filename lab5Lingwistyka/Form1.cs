using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab5Lingwistyka
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            textBox1.Text = "3.4+5/8.2*11^4;";
        }
        Regex regex;
        Match match;

        private void button1_Click(object sender, EventArgs e)
        {
            regex = new Regex(@"^[0-9]+(\.[0-9]+)?((\*|\:|\+|\-|\^)[0-9]+(\.[0-9]+)?)*;([0-9]+(\.[0-9]+)?((\*|\:|\+|\-|\^)[0-9]+(\.[0-9]+)?)*;)*$");
            //Z nawiasami
            //regex = new Regex(@"^(([0-9]+(\.[0-9]+)?((\*|\:|\+|\-|\^)[0-9]+(\.[0-9]+)?)*)|(\([0-9]+(\.[0-9]+)?((\*|\:|\+|\-|\^)[0-9]+(\.[0-9]+)?)*)\))(((\*|\:|\+|\-|\^)[0-9]+(\.[0-9]+)?((\*|\:|\+|\-|\^)[0-9]+(\.[0-9]+)?)*)|((\*|\:|\+|\-|\^)\([0-9]+(\.[0-9]+)?((\*|\:|\+|\-|\^)[0-9]+(\.[0-9]+)?)*)\))*;((([0-9]+(\.[0-9]+)?((\*|\:|\+|\-|\^)[0-9]+(\.[0-9]+)?)*)|(\([0-9]+(\.[0-9]+)?((\*|\:|\+|\-|\^)[0-9]+(\.[0-9]+)?)*)\))(((\*|\:|\+|\-|\^)[0-9]+(\.[0-9]+)?((\*|\:|\+|\-|\^)[0-9]+(\.[0-9]+)?)*)|((\*|\:|\+|\-|\^)\([0-9]+(\.[0-9]+)?((\*|\:|\+|\-|\^)[0-9]+(\.[0-9]+)?)*)\))*;)*$");
            match = regex.Match(textBox1.Text);
            if (match.Success)
                label1.Text = "Wynik: Poprawne";
            else
                label1.Text = "Wynik: Niepoprawne";
        }
    }
}


/*/////////////////////////////////////////////
//////GRAMATYKA BEZ NAWIASOW Z UŁAMKAMI//////
/////////////////////////////////////////////
S ::= W ; Z		
Z ::= W ; Z | $ 	
W ::= RW'	
W'::= OW | $
R ::= LR'
R'::= .L | $
L ::= CL'
L'::= L | $
C ::= 0 | 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 9
O ::= * | : | + | - | ^
L::= C{C}
R::= C{C}[.C{C}]
W::= RW'
W::= R(OW|$)
W::= R{OR}
S::= W;{W;} 
S::= R{OR};{R{OR};} 
S::= C{C}[.C{C}]{OC{C}[.C{C}]};{C{C}[.C{C}]{OC{C}[.C{C}]};} 
C::= (0|..|9)
O::= (*|:|+|-|^)
S::= (0|..|9){(0|..|9)}[.(0|..|9){(0|..|9)}]{(*|:|+|-|^)(0|..|9){(0|..|9)}[.(0|..|9){(0|..|9)}]};{(0|..|9){(0|..|

9)}[.(0|..|9){(0|..|9)}]{(*|:|+|-|^)(0|..|9){(0|..|9)}[.(0|..|9){(0|..|9)}]};}

od początku				--> ^
C{C}					--> [0-9]+		--> raz lub więcej
[.C{C}]					--> (\.[0-9]+)?		--> raz lub 0 
{OC{C}[.C{C}]}				--> ((\*|\:|\+|\-|\^)[0-9]+(\.[0-9]+)?)*	--> 0 lub więcej
koniec 					--> $
C{C}[.C{C}]{OC{C}[.C{C}]};  
	{C{C}[.C{C}]{OC{C}[.C{C}]};} 
^[0-9]+(\.[0-9]+)?((\*|\:|\+|\-|\^)[0-9]+(\.[0-9]+)?)*;
	([0-9]+(\.[0-9]+)?((\*|\:|\+|\-|\^)[0-9]+(\.[0-9]+)?)*;)*$



/////////////////////////////////////////////
//////GRAMATYKA Z NAWIASAMI Z UŁAMKAMI///////
/////////////////////////////////////////////
S ::= W ; Z		
Z ::= W ; Z | $ 	
W ::= PW'		
W'::= OW | $
P ::= R | <W>		P ::= R | (W)		() zastąpione <> bo mi się myli
R ::= LR'
R'::= .L | $
L ::= CL'
L'::= L | $
C ::= 0 | 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 9
O ::= * | : | + | - | ^
$ --> pusty znak

L' = L | $
L' = CL' | $
L' = C{C} 
L ::= CL'
L ::= C{C} 
R'::= .L | $
R'::= [.C{C}]			=> wystąpi przecinek z cyfrą lub więcej cyfr LUB NIC 
R ::= LR'
R ::= C{C}[.C{C}]		=> wystąpi cyfra a może wiele i może po nich . i cyfra lub wiele
W'::= OW | $
W'::= OPW' | $
W'::= {OP}
W ::= (R | <W>)W'
W'::= {O(R | <W>)}
P ::= R | <W>
W ::= (R | <W>){O(R | <W>)}

S ::= W ; {W} 
W ::= (C{C}[.C{C}] | <W>){O(C{C}[.C{C}] | <W>)}



*/
