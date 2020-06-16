all: out.txt
	cat out.txt

out.txt: main.exe
	mono $< > out.txt

main.exe: main.cs integrator.dll
	mcs $< -reference:$(word 2,$^) $<

integrator.dll: ../integrator.cs ../../matlib/integration/quado8.cs
	mcs -target:library -out:$@ $^

clean:
	rm -f out* *.exe *.dll