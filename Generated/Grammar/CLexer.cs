//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.13.2
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from Grammar/C.g4 by ANTLR 4.13.2

// Unreachable code detected
#pragma warning disable 0162
// The variable '...' is assigned but its value is never used
#pragma warning disable 0219
// Missing XML comment for publicly visible type or member '...'
#pragma warning disable 1591
// Ambiguous reference in cref attribute
#pragma warning disable 419

using System;
using System.IO;
using System.Text;
using Antlr4.Runtime;
using Antlr4.Runtime.Atn;
using Antlr4.Runtime.Misc;
using DFA = Antlr4.Runtime.Dfa.DFA;

[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.13.2")]
[System.CLSCompliant(false)]
public partial class CLexer : Lexer {
	protected static DFA[] decisionToDFA;
	protected static PredictionContextCache sharedContextCache = new PredictionContextCache();
	public const int
		T__0=1, T__1=2, T__2=3, T__3=4, T__4=5, T__5=6, T__6=7, T__7=8, T__8=9, 
		T__9=10, T__10=11, T__11=12, T__12=13, T__13=14, T__14=15, T__15=16, T__16=17, 
		T__17=18, T__18=19, T__19=20, T__20=21, T__21=22, T__22=23, T__23=24, 
		T__24=25, T__25=26, T__26=27, T__27=28, T__28=29, T__29=30, T__30=31, 
		T__31=32, T__32=33, T__33=34, T__34=35, T__35=36, T__36=37, T__37=38, 
		T__38=39, T__39=40, T__40=41, T__41=42, T__42=43, T__43=44, T__44=45, 
		T__45=46, T__46=47, T__47=48, T__48=49, T__49=50, T__50=51, T__51=52, 
		T__52=53, T__53=54, T__54=55, T__55=56, T__56=57, T__57=58, CONSTANT=59, 
		INT=60, FLOAT=61, CHAR=62, IDENTIFIER=63, STRING_LITERAL=64, HEADER_FILE=65, 
		WS=66, COMMENT=67, LINE_COMMENT=68;
	public static string[] channelNames = {
		"DEFAULT_TOKEN_CHANNEL", "HIDDEN"
	};

	public static string[] modeNames = {
		"DEFAULT_MODE"
	};

	public static readonly string[] ruleNames = {
		"T__0", "T__1", "T__2", "T__3", "T__4", "T__5", "T__6", "T__7", "T__8", 
		"T__9", "T__10", "T__11", "T__12", "T__13", "T__14", "T__15", "T__16", 
		"T__17", "T__18", "T__19", "T__20", "T__21", "T__22", "T__23", "T__24", 
		"T__25", "T__26", "T__27", "T__28", "T__29", "T__30", "T__31", "T__32", 
		"T__33", "T__34", "T__35", "T__36", "T__37", "T__38", "T__39", "T__40", 
		"T__41", "T__42", "T__43", "T__44", "T__45", "T__46", "T__47", "T__48", 
		"T__49", "T__50", "T__51", "T__52", "T__53", "T__54", "T__55", "T__56", 
		"T__57", "CONSTANT", "INT", "FLOAT", "CHAR", "IDENTIFIER", "STRING_LITERAL", 
		"HEADER_FILE", "WS", "COMMENT", "LINE_COMMENT"
	};


	public CLexer(ICharStream input)
	: this(input, Console.Out, Console.Error) { }

	public CLexer(ICharStream input, TextWriter output, TextWriter errorOutput)
	: base(input, output, errorOutput)
	{
		Interpreter = new LexerATNSimulator(this, _ATN, decisionToDFA, sharedContextCache);
	}

	private static readonly string[] _LiteralNames = {
		null, "'#'", "'include'", "'<'", "'>'", "'int'", "'main'", "'('", "')'", 
		"','", "';'", "'['", "']'", "'='", "'*'", "'struct'", "'{'", "'}'", "'.'", 
		"'union'", "'gets'", "'puts'", "'printf'", "'scanf'", "'&'", "'if'", "'else'", 
		"'switch'", "'case'", "':'", "'break'", "'default'", "'for'", "'while'", 
		"'do'", "'return'", "'?'", "'float'", "'void'", "'char'", "'double'", 
		"'short'", "'long'", "'unsigned'", "'||'", "'&&'", "'=='", "'!='", "'<='", 
		"'>='", "'+'", "'-'", "'/'", "'%'", "'++'", "'--'", "'!'", "'~'", "'sizeof'"
	};
	private static readonly string[] _SymbolicNames = {
		null, null, null, null, null, null, null, null, null, null, null, null, 
		null, null, null, null, null, null, null, null, null, null, null, null, 
		null, null, null, null, null, null, null, null, null, null, null, null, 
		null, null, null, null, null, null, null, null, null, null, null, null, 
		null, null, null, null, null, null, null, null, null, null, null, "CONSTANT", 
		"INT", "FLOAT", "CHAR", "IDENTIFIER", "STRING_LITERAL", "HEADER_FILE", 
		"WS", "COMMENT", "LINE_COMMENT"
	};
	public static readonly IVocabulary DefaultVocabulary = new Vocabulary(_LiteralNames, _SymbolicNames);

	[NotNull]
	public override IVocabulary Vocabulary
	{
		get
		{
			return DefaultVocabulary;
		}
	}

	public override string GrammarFileName { get { return "C.g4"; } }

	public override string[] RuleNames { get { return ruleNames; } }

	public override string[] ChannelNames { get { return channelNames; } }

	public override string[] ModeNames { get { return modeNames; } }

	public override int[] SerializedAtn { get { return _serializedATN; } }

	static CLexer() {
		decisionToDFA = new DFA[_ATN.NumberOfDecisions];
		for (int i = 0; i < _ATN.NumberOfDecisions; i++) {
			decisionToDFA[i] = new DFA(_ATN.GetDecisionState(i), i);
		}
	}
	private static int[] _serializedATN = {
		4,0,68,454,6,-1,2,0,7,0,2,1,7,1,2,2,7,2,2,3,7,3,2,4,7,4,2,5,7,5,2,6,7,
		6,2,7,7,7,2,8,7,8,2,9,7,9,2,10,7,10,2,11,7,11,2,12,7,12,2,13,7,13,2,14,
		7,14,2,15,7,15,2,16,7,16,2,17,7,17,2,18,7,18,2,19,7,19,2,20,7,20,2,21,
		7,21,2,22,7,22,2,23,7,23,2,24,7,24,2,25,7,25,2,26,7,26,2,27,7,27,2,28,
		7,28,2,29,7,29,2,30,7,30,2,31,7,31,2,32,7,32,2,33,7,33,2,34,7,34,2,35,
		7,35,2,36,7,36,2,37,7,37,2,38,7,38,2,39,7,39,2,40,7,40,2,41,7,41,2,42,
		7,42,2,43,7,43,2,44,7,44,2,45,7,45,2,46,7,46,2,47,7,47,2,48,7,48,2,49,
		7,49,2,50,7,50,2,51,7,51,2,52,7,52,2,53,7,53,2,54,7,54,2,55,7,55,2,56,
		7,56,2,57,7,57,2,58,7,58,2,59,7,59,2,60,7,60,2,61,7,61,2,62,7,62,2,63,
		7,63,2,64,7,64,2,65,7,65,2,66,7,66,2,67,7,67,1,0,1,0,1,1,1,1,1,1,1,1,1,
		1,1,1,1,1,1,1,1,2,1,2,1,3,1,3,1,4,1,4,1,4,1,4,1,5,1,5,1,5,1,5,1,5,1,6,
		1,6,1,7,1,7,1,8,1,8,1,9,1,9,1,10,1,10,1,11,1,11,1,12,1,12,1,13,1,13,1,
		14,1,14,1,14,1,14,1,14,1,14,1,14,1,15,1,15,1,16,1,16,1,17,1,17,1,18,1,
		18,1,18,1,18,1,18,1,18,1,19,1,19,1,19,1,19,1,19,1,20,1,20,1,20,1,20,1,
		20,1,21,1,21,1,21,1,21,1,21,1,21,1,21,1,22,1,22,1,22,1,22,1,22,1,22,1,
		23,1,23,1,24,1,24,1,24,1,25,1,25,1,25,1,25,1,25,1,26,1,26,1,26,1,26,1,
		26,1,26,1,26,1,27,1,27,1,27,1,27,1,27,1,28,1,28,1,29,1,29,1,29,1,29,1,
		29,1,29,1,30,1,30,1,30,1,30,1,30,1,30,1,30,1,30,1,31,1,31,1,31,1,31,1,
		32,1,32,1,32,1,32,1,32,1,32,1,33,1,33,1,33,1,34,1,34,1,34,1,34,1,34,1,
		34,1,34,1,35,1,35,1,36,1,36,1,36,1,36,1,36,1,36,1,37,1,37,1,37,1,37,1,
		37,1,38,1,38,1,38,1,38,1,38,1,39,1,39,1,39,1,39,1,39,1,39,1,39,1,40,1,
		40,1,40,1,40,1,40,1,40,1,41,1,41,1,41,1,41,1,41,1,42,1,42,1,42,1,42,1,
		42,1,42,1,42,1,42,1,42,1,43,1,43,1,43,1,44,1,44,1,44,1,45,1,45,1,45,1,
		46,1,46,1,46,1,47,1,47,1,47,1,48,1,48,1,48,1,49,1,49,1,50,1,50,1,51,1,
		51,1,52,1,52,1,53,1,53,1,53,1,54,1,54,1,54,1,55,1,55,1,56,1,56,1,57,1,
		57,1,57,1,57,1,57,1,57,1,57,1,58,1,58,1,58,3,58,368,8,58,1,59,4,59,371,
		8,59,11,59,12,59,372,1,60,4,60,376,8,60,11,60,12,60,377,1,60,1,60,4,60,
		382,8,60,11,60,12,60,383,1,61,1,61,1,61,1,61,1,62,1,62,5,62,392,8,62,10,
		62,12,62,395,9,62,1,63,1,63,1,63,1,63,5,63,401,8,63,10,63,12,63,404,9,
		63,1,63,1,63,1,64,1,64,5,64,410,8,64,10,64,12,64,413,9,64,1,64,1,64,1,
		64,5,64,418,8,64,10,64,12,64,421,9,64,1,65,4,65,424,8,65,11,65,12,65,425,
		1,65,1,65,1,66,1,66,1,66,1,66,5,66,434,8,66,10,66,12,66,437,9,66,1,66,
		1,66,1,66,1,66,1,66,1,67,1,67,1,67,1,67,5,67,448,8,67,10,67,12,67,451,
		9,67,1,67,1,67,1,435,0,68,1,1,3,2,5,3,7,4,9,5,11,6,13,7,15,8,17,9,19,10,
		21,11,23,12,25,13,27,14,29,15,31,16,33,17,35,18,37,19,39,20,41,21,43,22,
		45,23,47,24,49,25,51,26,53,27,55,28,57,29,59,30,61,31,63,32,65,33,67,34,
		69,35,71,36,73,37,75,38,77,39,79,40,81,41,83,42,85,43,87,44,89,45,91,46,
		93,47,95,48,97,49,99,50,101,51,103,52,105,53,107,54,109,55,111,56,113,
		57,115,58,117,59,119,60,121,61,123,62,125,63,127,64,129,65,131,66,133,
		67,135,68,1,0,6,1,0,48,57,3,0,65,90,95,95,97,122,4,0,48,57,65,90,95,95,
		97,122,2,0,34,34,92,92,3,0,9,10,13,13,32,32,2,0,10,10,13,13,466,0,1,1,
		0,0,0,0,3,1,0,0,0,0,5,1,0,0,0,0,7,1,0,0,0,0,9,1,0,0,0,0,11,1,0,0,0,0,13,
		1,0,0,0,0,15,1,0,0,0,0,17,1,0,0,0,0,19,1,0,0,0,0,21,1,0,0,0,0,23,1,0,0,
		0,0,25,1,0,0,0,0,27,1,0,0,0,0,29,1,0,0,0,0,31,1,0,0,0,0,33,1,0,0,0,0,35,
		1,0,0,0,0,37,1,0,0,0,0,39,1,0,0,0,0,41,1,0,0,0,0,43,1,0,0,0,0,45,1,0,0,
		0,0,47,1,0,0,0,0,49,1,0,0,0,0,51,1,0,0,0,0,53,1,0,0,0,0,55,1,0,0,0,0,57,
		1,0,0,0,0,59,1,0,0,0,0,61,1,0,0,0,0,63,1,0,0,0,0,65,1,0,0,0,0,67,1,0,0,
		0,0,69,1,0,0,0,0,71,1,0,0,0,0,73,1,0,0,0,0,75,1,0,0,0,0,77,1,0,0,0,0,79,
		1,0,0,0,0,81,1,0,0,0,0,83,1,0,0,0,0,85,1,0,0,0,0,87,1,0,0,0,0,89,1,0,0,
		0,0,91,1,0,0,0,0,93,1,0,0,0,0,95,1,0,0,0,0,97,1,0,0,0,0,99,1,0,0,0,0,101,
		1,0,0,0,0,103,1,0,0,0,0,105,1,0,0,0,0,107,1,0,0,0,0,109,1,0,0,0,0,111,
		1,0,0,0,0,113,1,0,0,0,0,115,1,0,0,0,0,117,1,0,0,0,0,119,1,0,0,0,0,121,
		1,0,0,0,0,123,1,0,0,0,0,125,1,0,0,0,0,127,1,0,0,0,0,129,1,0,0,0,0,131,
		1,0,0,0,0,133,1,0,0,0,0,135,1,0,0,0,1,137,1,0,0,0,3,139,1,0,0,0,5,147,
		1,0,0,0,7,149,1,0,0,0,9,151,1,0,0,0,11,155,1,0,0,0,13,160,1,0,0,0,15,162,
		1,0,0,0,17,164,1,0,0,0,19,166,1,0,0,0,21,168,1,0,0,0,23,170,1,0,0,0,25,
		172,1,0,0,0,27,174,1,0,0,0,29,176,1,0,0,0,31,183,1,0,0,0,33,185,1,0,0,
		0,35,187,1,0,0,0,37,189,1,0,0,0,39,195,1,0,0,0,41,200,1,0,0,0,43,205,1,
		0,0,0,45,212,1,0,0,0,47,218,1,0,0,0,49,220,1,0,0,0,51,223,1,0,0,0,53,228,
		1,0,0,0,55,235,1,0,0,0,57,240,1,0,0,0,59,242,1,0,0,0,61,248,1,0,0,0,63,
		256,1,0,0,0,65,260,1,0,0,0,67,266,1,0,0,0,69,269,1,0,0,0,71,276,1,0,0,
		0,73,278,1,0,0,0,75,284,1,0,0,0,77,289,1,0,0,0,79,294,1,0,0,0,81,301,1,
		0,0,0,83,307,1,0,0,0,85,312,1,0,0,0,87,321,1,0,0,0,89,324,1,0,0,0,91,327,
		1,0,0,0,93,330,1,0,0,0,95,333,1,0,0,0,97,336,1,0,0,0,99,339,1,0,0,0,101,
		341,1,0,0,0,103,343,1,0,0,0,105,345,1,0,0,0,107,347,1,0,0,0,109,350,1,
		0,0,0,111,353,1,0,0,0,113,355,1,0,0,0,115,357,1,0,0,0,117,367,1,0,0,0,
		119,370,1,0,0,0,121,375,1,0,0,0,123,385,1,0,0,0,125,389,1,0,0,0,127,396,
		1,0,0,0,129,407,1,0,0,0,131,423,1,0,0,0,133,429,1,0,0,0,135,443,1,0,0,
		0,137,138,5,35,0,0,138,2,1,0,0,0,139,140,5,105,0,0,140,141,5,110,0,0,141,
		142,5,99,0,0,142,143,5,108,0,0,143,144,5,117,0,0,144,145,5,100,0,0,145,
		146,5,101,0,0,146,4,1,0,0,0,147,148,5,60,0,0,148,6,1,0,0,0,149,150,5,62,
		0,0,150,8,1,0,0,0,151,152,5,105,0,0,152,153,5,110,0,0,153,154,5,116,0,
		0,154,10,1,0,0,0,155,156,5,109,0,0,156,157,5,97,0,0,157,158,5,105,0,0,
		158,159,5,110,0,0,159,12,1,0,0,0,160,161,5,40,0,0,161,14,1,0,0,0,162,163,
		5,41,0,0,163,16,1,0,0,0,164,165,5,44,0,0,165,18,1,0,0,0,166,167,5,59,0,
		0,167,20,1,0,0,0,168,169,5,91,0,0,169,22,1,0,0,0,170,171,5,93,0,0,171,
		24,1,0,0,0,172,173,5,61,0,0,173,26,1,0,0,0,174,175,5,42,0,0,175,28,1,0,
		0,0,176,177,5,115,0,0,177,178,5,116,0,0,178,179,5,114,0,0,179,180,5,117,
		0,0,180,181,5,99,0,0,181,182,5,116,0,0,182,30,1,0,0,0,183,184,5,123,0,
		0,184,32,1,0,0,0,185,186,5,125,0,0,186,34,1,0,0,0,187,188,5,46,0,0,188,
		36,1,0,0,0,189,190,5,117,0,0,190,191,5,110,0,0,191,192,5,105,0,0,192,193,
		5,111,0,0,193,194,5,110,0,0,194,38,1,0,0,0,195,196,5,103,0,0,196,197,5,
		101,0,0,197,198,5,116,0,0,198,199,5,115,0,0,199,40,1,0,0,0,200,201,5,112,
		0,0,201,202,5,117,0,0,202,203,5,116,0,0,203,204,5,115,0,0,204,42,1,0,0,
		0,205,206,5,112,0,0,206,207,5,114,0,0,207,208,5,105,0,0,208,209,5,110,
		0,0,209,210,5,116,0,0,210,211,5,102,0,0,211,44,1,0,0,0,212,213,5,115,0,
		0,213,214,5,99,0,0,214,215,5,97,0,0,215,216,5,110,0,0,216,217,5,102,0,
		0,217,46,1,0,0,0,218,219,5,38,0,0,219,48,1,0,0,0,220,221,5,105,0,0,221,
		222,5,102,0,0,222,50,1,0,0,0,223,224,5,101,0,0,224,225,5,108,0,0,225,226,
		5,115,0,0,226,227,5,101,0,0,227,52,1,0,0,0,228,229,5,115,0,0,229,230,5,
		119,0,0,230,231,5,105,0,0,231,232,5,116,0,0,232,233,5,99,0,0,233,234,5,
		104,0,0,234,54,1,0,0,0,235,236,5,99,0,0,236,237,5,97,0,0,237,238,5,115,
		0,0,238,239,5,101,0,0,239,56,1,0,0,0,240,241,5,58,0,0,241,58,1,0,0,0,242,
		243,5,98,0,0,243,244,5,114,0,0,244,245,5,101,0,0,245,246,5,97,0,0,246,
		247,5,107,0,0,247,60,1,0,0,0,248,249,5,100,0,0,249,250,5,101,0,0,250,251,
		5,102,0,0,251,252,5,97,0,0,252,253,5,117,0,0,253,254,5,108,0,0,254,255,
		5,116,0,0,255,62,1,0,0,0,256,257,5,102,0,0,257,258,5,111,0,0,258,259,5,
		114,0,0,259,64,1,0,0,0,260,261,5,119,0,0,261,262,5,104,0,0,262,263,5,105,
		0,0,263,264,5,108,0,0,264,265,5,101,0,0,265,66,1,0,0,0,266,267,5,100,0,
		0,267,268,5,111,0,0,268,68,1,0,0,0,269,270,5,114,0,0,270,271,5,101,0,0,
		271,272,5,116,0,0,272,273,5,117,0,0,273,274,5,114,0,0,274,275,5,110,0,
		0,275,70,1,0,0,0,276,277,5,63,0,0,277,72,1,0,0,0,278,279,5,102,0,0,279,
		280,5,108,0,0,280,281,5,111,0,0,281,282,5,97,0,0,282,283,5,116,0,0,283,
		74,1,0,0,0,284,285,5,118,0,0,285,286,5,111,0,0,286,287,5,105,0,0,287,288,
		5,100,0,0,288,76,1,0,0,0,289,290,5,99,0,0,290,291,5,104,0,0,291,292,5,
		97,0,0,292,293,5,114,0,0,293,78,1,0,0,0,294,295,5,100,0,0,295,296,5,111,
		0,0,296,297,5,117,0,0,297,298,5,98,0,0,298,299,5,108,0,0,299,300,5,101,
		0,0,300,80,1,0,0,0,301,302,5,115,0,0,302,303,5,104,0,0,303,304,5,111,0,
		0,304,305,5,114,0,0,305,306,5,116,0,0,306,82,1,0,0,0,307,308,5,108,0,0,
		308,309,5,111,0,0,309,310,5,110,0,0,310,311,5,103,0,0,311,84,1,0,0,0,312,
		313,5,117,0,0,313,314,5,110,0,0,314,315,5,115,0,0,315,316,5,105,0,0,316,
		317,5,103,0,0,317,318,5,110,0,0,318,319,5,101,0,0,319,320,5,100,0,0,320,
		86,1,0,0,0,321,322,5,124,0,0,322,323,5,124,0,0,323,88,1,0,0,0,324,325,
		5,38,0,0,325,326,5,38,0,0,326,90,1,0,0,0,327,328,5,61,0,0,328,329,5,61,
		0,0,329,92,1,0,0,0,330,331,5,33,0,0,331,332,5,61,0,0,332,94,1,0,0,0,333,
		334,5,60,0,0,334,335,5,61,0,0,335,96,1,0,0,0,336,337,5,62,0,0,337,338,
		5,61,0,0,338,98,1,0,0,0,339,340,5,43,0,0,340,100,1,0,0,0,341,342,5,45,
		0,0,342,102,1,0,0,0,343,344,5,47,0,0,344,104,1,0,0,0,345,346,5,37,0,0,
		346,106,1,0,0,0,347,348,5,43,0,0,348,349,5,43,0,0,349,108,1,0,0,0,350,
		351,5,45,0,0,351,352,5,45,0,0,352,110,1,0,0,0,353,354,5,33,0,0,354,112,
		1,0,0,0,355,356,5,126,0,0,356,114,1,0,0,0,357,358,5,115,0,0,358,359,5,
		105,0,0,359,360,5,122,0,0,360,361,5,101,0,0,361,362,5,111,0,0,362,363,
		5,102,0,0,363,116,1,0,0,0,364,368,3,119,59,0,365,368,3,121,60,0,366,368,
		3,123,61,0,367,364,1,0,0,0,367,365,1,0,0,0,367,366,1,0,0,0,368,118,1,0,
		0,0,369,371,7,0,0,0,370,369,1,0,0,0,371,372,1,0,0,0,372,370,1,0,0,0,372,
		373,1,0,0,0,373,120,1,0,0,0,374,376,7,0,0,0,375,374,1,0,0,0,376,377,1,
		0,0,0,377,375,1,0,0,0,377,378,1,0,0,0,378,379,1,0,0,0,379,381,5,46,0,0,
		380,382,7,0,0,0,381,380,1,0,0,0,382,383,1,0,0,0,383,381,1,0,0,0,383,384,
		1,0,0,0,384,122,1,0,0,0,385,386,5,39,0,0,386,387,9,0,0,0,387,388,5,39,
		0,0,388,124,1,0,0,0,389,393,7,1,0,0,390,392,7,2,0,0,391,390,1,0,0,0,392,
		395,1,0,0,0,393,391,1,0,0,0,393,394,1,0,0,0,394,126,1,0,0,0,395,393,1,
		0,0,0,396,402,5,34,0,0,397,401,8,3,0,0,398,399,5,92,0,0,399,401,9,0,0,
		0,400,397,1,0,0,0,400,398,1,0,0,0,401,404,1,0,0,0,402,400,1,0,0,0,402,
		403,1,0,0,0,403,405,1,0,0,0,404,402,1,0,0,0,405,406,5,34,0,0,406,128,1,
		0,0,0,407,411,7,1,0,0,408,410,7,2,0,0,409,408,1,0,0,0,410,413,1,0,0,0,
		411,409,1,0,0,0,411,412,1,0,0,0,412,414,1,0,0,0,413,411,1,0,0,0,414,415,
		5,46,0,0,415,419,7,1,0,0,416,418,7,2,0,0,417,416,1,0,0,0,418,421,1,0,0,
		0,419,417,1,0,0,0,419,420,1,0,0,0,420,130,1,0,0,0,421,419,1,0,0,0,422,
		424,7,4,0,0,423,422,1,0,0,0,424,425,1,0,0,0,425,423,1,0,0,0,425,426,1,
		0,0,0,426,427,1,0,0,0,427,428,6,65,0,0,428,132,1,0,0,0,429,430,5,47,0,
		0,430,431,5,42,0,0,431,435,1,0,0,0,432,434,9,0,0,0,433,432,1,0,0,0,434,
		437,1,0,0,0,435,436,1,0,0,0,435,433,1,0,0,0,436,438,1,0,0,0,437,435,1,
		0,0,0,438,439,5,42,0,0,439,440,5,47,0,0,440,441,1,0,0,0,441,442,6,66,0,
		0,442,134,1,0,0,0,443,444,5,47,0,0,444,445,5,47,0,0,445,449,1,0,0,0,446,
		448,8,5,0,0,447,446,1,0,0,0,448,451,1,0,0,0,449,447,1,0,0,0,449,450,1,
		0,0,0,450,452,1,0,0,0,451,449,1,0,0,0,452,453,6,67,0,0,453,136,1,0,0,0,
		13,0,367,372,377,383,393,400,402,411,419,425,435,449,1,6,0,0
	};

	public static readonly ATN _ATN =
		new ATNDeserializer().Deserialize(_serializedATN);


}
