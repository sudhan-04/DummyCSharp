#ifndef I_USERINTERFACE_HPP
#define I_USERINTERFACE_HPP

class IUserInterface 
{
    private:
        virtual int GetFirstInteger() = 0;
        virtual int GetSecondInteger() = 0;
    public:
        virtual void Run() = 0;
};

#endif
