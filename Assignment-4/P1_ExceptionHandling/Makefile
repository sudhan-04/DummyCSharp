CXX = g++
CXXFLAGS = -Wall -std=c++14
 
TARGET = ExceptionHandling
SRCDIR = src

SRCS = $(wildcard $(SRCDIR)/Entity/*.cpp) $(wildcard $(SRCDIR)/*.cpp)
OBJS = $(SRCS:.cpp=.o)
 
all: $(TARGET) run
 
$(TARGET): $(OBJS)
	$(CXX) $(CXXFLAGS) -o $(TARGET) $^
 
%.o: %.cpp
	$(CXX) $(CXXFLAGS) -c $< -o $@
 
run: $(TARGET)
	./$(TARGET)
 
clean:
	rm -f $(TARGET).exe $(OBJS)
 
.PHONY: all clean run
 