using System;
using System.Collections.Generic;

namespace Mediator
{
    //Mediator patterni, ayni tip veya aynı inteface'i implemente eden nesnelerin birbiriyle ilişki kurabilmesini sağlayan tasarım desenidir.
    class Program
    {
        static void Main(string[] args)
        {
            Mediator mediator = new Mediator();
            Teacher teacher = new Teacher(mediator);
            teacher.Name = "Engin";

            mediator.Teacher = teacher;

            Student student = new Student(mediator);
            student.Name = "Derin";

            Student student2 = new Student(mediator);
            student2.Name = "Salih";

            mediator.Students = new List<Student> {student,student2 };
            teacher.RecieveQuestion("is it true?",student2);

            teacher.SendNewImageUrl("slide1.jpg");
        }
    }
    abstract class CourseMember
    {
        protected Mediator Mediator;

        protected CourseMember(Mediator mediator)
        {
            Mediator = mediator;
        }
    }
    class Teacher : CourseMember
    {
        public string Name { get; internal set; }

        public Teacher(Mediator mediator) : base(mediator)
        {

        }
        internal void RecieveQuestion(string question, Student student)
        {
            Console.WriteLine("Teacher recieved  a question from {0},{1}", student.Name, question);
        }
        public void SendNewImageUrl(string url)
        {
            Console.WriteLine("Teacher changed slide : {0}", url);
            Mediator.UpdateImage(url);
        }
        public void AnswerQuestion(string answer, Student student)
        {
            Console.WriteLine("Teacher answered question {0},{1}", student.Name, answer);
        }
    }
    class Student : CourseMember
    {
        public Student(Mediator mediator) : base(mediator)
        {
        }

        public string Name { get; internal set; }

        internal void RecieveImage(string url)
        {
            Console.WriteLine("{1} recieved image : {0}", url,Name);
        }

        internal void RecieveAnswer(string answer)
        {
            Console.WriteLine("Student recieved answer [0}", answer);
        }
    }
    class Mediator
    {
        public Teacher Teacher { get; set; }
        public List<Student> Students { get; set; }

        public void UpdateImage(string url)
        {
            foreach (var student in Students)
            {
                student.RecieveImage(url);
            }
        }

        public void SendQuestion(string question, Student student)
        {
            Teacher.RecieveQuestion(question, student);
        }

        public void SendAnswer(string answer, Student student)
        {
            student.RecieveAnswer(answer);
        }
    }
}
