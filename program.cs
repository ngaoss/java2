import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;

public class Main {
    static List<Student> studentList = new ArrayList<>();

    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int choice;

        do {
            System.out.println("\n----------------Menu----------------");
            System.out.println("1. input students");
            System.out.println("2. display students");
            System.out.println("3. remove student by code");
            System.out.println("4. sort students by grade (descending)");
            System.out.println("5. find student by code or name");
            System.out.println("6. filter students by minimum grade");
            System.out.println("0. exit");
            System.out.print("enter your choice: ");
            choice = scanner.nextInt();
            scanner.nextLine();
            switch (choice) {
                case 1:
                    inputStudents();
                    break;
                case 2:
                    output();
                    break;
                case 3:
                    System.out.print("enter student code to remove: ");
                    String code = scanner.nextLine();
                    removeByCode(code);
                    break;
                case 4:
                    sortByGradeDesc();
                    System.out.println("students sorted by grade in descending order.");
                    break;
                case 5:
                    System.out.print("enter student code or name to find: ");
                    String keyword = scanner.nextLine();
                    Student foundStudent = findByCodeOrName(keyword);
                    if (foundStudent != null) {
                        System.out.println("student found: " + foundStudent);
                    } else {
                        System.out.println("student not found.");
                    }
                    break;
                case 6:
                    System.out.print("enter minimum grade to filter: ");
                    float grade = scanner.nextFloat();
                    scanner.nextLine(); // Consume newline
                    List<Student> filteredStudents = filterByGrade(grade);
                    if (!filteredStudents.isEmpty()) {
                        System.out.println("filtered students:");
                        for (Student student : filteredStudents) {
                            System.out.println(student);
                        }
                    } else {
                        System.out.println("no students found with the given minimum grade.");
                    }
                    break;
                case 0:
                    System.out.println("exiting the program.");
                    break;
                default:
                    System.out.println("invalid choice. please try again.");
            }
        } while (choice != 0);
    }

    public static void inputStudents() {
        Scanner scanner = new Scanner(System.in);
        System.out.print("input number of students: ");
        int n = scanner.nextInt();
        scanner.nextLine();

        for (int i = 1; i <= n; i++) {
            input();
        }
    }

    public static void input() {
        Scanner scanner = new Scanner(System.in);
        System.out.println("-------------input information for student-------------");
        System.out.print("input student ID: ");
        String code = scanner.nextLine();
        System.out.print("input student name: ");
        String name = scanner.nextLine();
        System.out.print("input grade: ");
        float grade = scanner.nextFloat();
        scanner.nextLine();

        Student student = new Student(code, name, grade);
        studentList.add(student);
    }

    public static void output() {
        for (Student student : studentList) {
            System.out.println(student.toString());
        }
    }

    public static void removeByCode(String code) {
        boolean removed = studentList.removeIf(student -> student.getCode().equals(code));
        if (removed) {
            System.out.println("student removed.");
        } else {
            System.out.println("student not found.");
        }
    }

    public static void sortByGradeDesc() {
        studentList.sort((s1, s2) -> Float.compare(s2.getGrade(), s1.getGrade()));
    }

    public static Student findByCodeOrName(String keyword) {
        for (Student student : studentList) {
            if (student.getCode().equals(keyword) || student.getName().equals(keyword)) {
                return student;
            }
        }
        return null;
    }

    public static List<Student> filterByGrade(float x) {
        List<Student> filteredStudents = new ArrayList<>();
        for (Student student : studentList) {
            if (student.getGrade() >= x) {
                filteredStudents.add(student);
            }
        }
        return filteredStudents;
    }

    static class Student {
        private String code;
        private String name;
        private float grade;

        public Student(String code, String name, float grade) {
            this.code = code;
            this.name = name;
            this.grade = grade;
        }

        public String getCode() {
            return code;
        }

        public void setCode(String code) {
            this.code = code;
        }

        public String getName() {
            return name;
        }

        public void setName(String name) {
            this.name = name;
        }

        public float getGrade() {
            return grade;
        }

        public void setGrade(float grade) {
            this.grade = grade;
        }

        @Override
        public String toString() {
            return "Student{" +
                    "code='" + code + '\'' +
                    ", name='" + name + '\'' +
                    ", grade=" + grade +
                    '}';
        }
    }
}
