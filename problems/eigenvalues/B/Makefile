all: plot1.svg 
	cat out.txt
plot1.svg: plot1.gpi timedata.txt
	gnuplot $<
out.txt timedata.txt : main.exe timedata.txt
	mono $< > out.txt

main.exe: main.cs jaobi.dll
	mcs -reference:$(word 2,$^) $<	

MATLIB = ../../matlib
S := $(MATLIB)/matrix/matrix.cs
S += $(MATLIB)/matrix/vector.cs
jaobi.dll: ../jaobi.cs  $(S)
	mcs -target:library -out:$@ $^

clean:
	rm -f rm *.exe out* *.svg *.dll timedata.txt
