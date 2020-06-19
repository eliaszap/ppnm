all: plot.svg out.txt
	cat out.txt

plot.svg: plot.gpi d1.txt d2.txt d3.txt 
	gnuplot $<

out.txt d1.txt d2.txt d3.txt: main.exe 
	mono $< > out.txt

main.exe: main.cs jaobi.dll
	mcs -reference:$(word 2,$^) $<	

MATLIB = ../../matlib
S := $(MATLIB)/matrix/matrix.cs
S += $(MATLIB)/matrix/vector.cs
jaobi.dll: ../jaobi.cs  $(S)
	mcs -target:library -out:$@ $^

clean:
	rm -f rm *.exe out.txt data.txt *.svg *.dll d*
