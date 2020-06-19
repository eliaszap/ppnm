all: out.txt
	cat out.txt

out.txt: main.exe
	mono $< > out.txt

main.exe: main.cs root.dll
	mcs $< -reference:$(word 2,$^) $<

MATLIB = ../../matlib
S := $(MATLIB)/matrix/matrix.cs
S += $(MATLIB)/matrix/vector.cs
S += ../../linear_equation/qrdecompositionGS.cs
S += ../ODE.cs
root.dll: ../root.cs $(S)
	mcs -target:library -out:$@ $^

clean:
	rm -f out* *.exe *.dll
