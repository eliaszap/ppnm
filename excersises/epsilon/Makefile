CSFLAGS =-warn:2 -optimize-
all: out.txt
	cat $<

out.txt : epsmain.exe
	mono epsmain.exe > out.txt
epsmain.exe : epsmain.cs epsilonD.dll
	mcs  $(CSFALGS) -reference:epsilonD.dll -out:epsmain.exe epsmain.cs
epsilonD.dll : epsilonD.cs
	mcs $(CSFLAGS) -target:library -out:$@ $<
clean :
	rm -f out.txt epsmain.exe
