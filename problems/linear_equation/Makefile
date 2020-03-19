all: out.txt
	cat out.txt
out.txt: main.exe
	mono $< > out.txt
	
main.exe: main.cs qrdecompositionGS.dll
	mcs $< -reference:$(word 2, $^) $<	
MATLIB = ../matlib
S :=$(MATLIB)/matrix/matrix.cs
S +=$(MATLIB)/matrix/vector.cs
qrdecompositionGS.dll: qrdecompositionGS.cs $(S)
	mcs -target:library -out:$@ $^

clean:
	rm -f 	out* *.exe 