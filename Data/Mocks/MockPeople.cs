using DatingSite.Data.Models;

namespace DatingSite.Data.Mocks
{
    static public class MockPeople
    {
        static public User User = new User()
        {
            Id = Guid.NewGuid(),
            BlankId = Guid.NewGuid(),
            Email = "ann.andreikovets@gmail.com",
            Password = "qwerty1234M"
        };

        static List<Blank> blanks = new List<Blank>()
        {
            new Blank()
            {
                Id = Guid.NewGuid(),
                FirstName = "Alexandr",
                SecondName = "Maskev",
                Years = 22,
                Photo = "/img/AlexandrMaksev.jpg",
                Description = "Hi, baby. I am a rock music enthusiast who has a passion for motorcycles and takes pride in his appearance. Rock music has always been a significant part of my life. The raw energy, powerful lyrics, and electric guitar solos ignite a fire within me. Attending concerts, playing air guitar in my living room, or simply listening to my favorite bands with the volume turned up - it's all a part of my rock and roll lifestyle. Motorcycles are my other love. The thrill of the open road, the freedom of riding, and the sense of adventure that comes with it captivate my spirit. Exploring new destinations, feeling the wind against my face, and experiencing the world from a unique perspective brings me immense joy and excitement. When it comes to personal care and style, I take great care in my appearance. Grooming, dressing well, and paying attention to details are important aspects of my daily routine. I believe that taking care of oneself reflects self-respect and boosts confidence. Looking good and feeling good go hand in hand for me. I am looking for someone who shares my love for rock music, adventure on two wheels, and appreciates the importance of self-care. A partner who enjoys attending concerts, going on motorcycle rides, and values personal style. Let's rock out together, explore the open road, and create a beautiful harmony in our lives. ",
                Sex = "male",
                PreferSex = "female"
            },
            new Blank()
            {
                Id = Guid.NewGuid(),
                FirstName = "Andrey",
                SecondName = "Kulkov",
                Years = 25,
                Photo = "/img/AndreyKulkov.jpg",
                Description = "I am an architect with a creative soul who promises an unforgettable evening. As an architect, I have the privilege of transforming imagination into reality. Designing spaces that inspire, evoke emotions, and improve lives is my greatest passion. I am fascinated by the intricate balance between aesthetics and functionality, and I find joy in every project I undertake. Creativity is at the core of my being. Beyond my professional work, I seek out creative outlets in various forms. Whether it's painting, writing, or exploring new artistic endeavors, I am constantly seeking inspiration and finding ways to express my innermost thoughts and ideas. When it comes to spending quality time together, I promise an unforgettable evening. Whether it's a romantic candlelit dinner at a cozy restaurant, a spontaneous adventure to a hidden gem, or simply engaging in meaningful conversations under the moonlit sky, I believe in creating moments that will be cherished forever. I will put in the effort to ensure that our time together is filled with laughter, connection, and a touch of magic. I am looking for someone who appreciates art, creativity, and intellectual conversations. A partner who is open to new experiences, has a zest for life, and savors the beauty in every moment. Let's embark on a journey of discovery, create our own masterpiece of love, and make memories that will last a lifetime.",
                Sex = "male",
                PreferSex = "female"
            },
            new Blank()
            {
                Id = Guid.NewGuid(),
                FirstName = "Oleg",
                SecondName = "Smishkev",
                Years = 42,
                Photo = "/img/OlegSmishkev.jpg",
                Description = "Hello, dear. I am an enterprising businessman with a successful café. I welcome you to indulge in a culinary experience where you can enjoy any dish, courtesy of my generosity. I am also a proud father to a wonderful daughter from my previous marriage. Being an entrepreneur and owning my own café has been an exciting and fulfilling journey for me. I am passionate about creating a warm and inviting atmosphere for my guests, and providing them with a delightful culinary experience. From delectable appetizers to mouthwatering main courses and irresistible desserts, my café offers a wide range of culinary delights that are sure to please any palate. In addition to my business endeavors, I am also a doting father to a lovely daughter. She holds a special place in my heart and brings immense joy into my life. As a responsible parent, I prioritize her well-being and ensure that she has the support and love she needs. I am looking for a partner who appreciates good food and enjoys exploring different flavors. Someone who understands the demands of entrepreneurship and respects the importance of family. Let's share memorable meals, laughter, and rich experiences together. Join me as we savor the finer things in life, create lasting connections, and enjoy the journey of parenthood. ",
                Sex = "male",
                PreferSex = "female"
            },
            new Blank()
            {
                Id = Guid.NewGuid(),
                FirstName = "Ronaldo",
                SecondName = "Evrikan",
                Years = 37,
                Photo = "/img/RonaldoEvrikan.jpg",
                Description = "I am a man who appreciates fine red wine, aspires to build a family, has his own business, and enjoys exploring the world of art in museums. Red wine is not just a drink for me; it embodies elegance, sophistication, and the art of winemaking. The rich flavors, aromas, and textures of a good red wine transport me to a place of relaxation and pleasure. I take pleasure in exploring different varieties, pairing them with delectable dishes, and savoring the depth and complexity they offer. Building a family is a dream close to my heart. I believe in the power of love, commitment, and shared experiences. I envision a future where I can provide a loving, supportive, and nurturing environment for my partner and our children. Creating memories, experiencing milestones together, and fostering a sense of belonging and happiness is what I strive for. As a business owner, I value the freedom, creativity, and responsibility that comes with it. Running my own business allows me to channel my entrepreneurial spirit, make an impact in my chosen field, and create opportunities for personal and professional growth. Art and culture fascinate me, and I find great pleasure in exploring museums. The beauty of paintings, sculptures, and various art forms captivates my imagination and stirs my soul. Museums provide a window into the human experience, and I enjoy the intellectual stimulation and inspiration they offer. I am looking for a partner who shares my appreciation for the finer things in life, embraces the idea of family, and values the importance of personal and professional growth. If you enjoy the art of conversation, the taste of good wine, and the prospect of building a loving family, let's embark on this journey together. Together, we can create a life filled with love, laughter, and meaningful experiences.",
                Sex = "male",
                PreferSex = "female"
            },
            new Blank()
            {
                Id = Guid.NewGuid(),
                FirstName = "Volodya",
                SecondName = "Martiskin",
                Years = 36,
                Photo = "/img/VolodyaMartiskin.jpg",
                Description = "I am a passionate and adventurous man who enjoys evening strolls and cooking. Passion runs through my veins, whether it's pursuing my hobbies, engaging in meaningful conversations, or expressing love and affection towards the people important to me. I believe in living life to the fullest, embracing every moment, and approaching everything with enthusiasm. One of my favorite activities is taking evening walks. There is something magical about the peacefulness of the twilight hours, the gentle breeze, and the tranquility of the world around us. Walking allows me to clear my mind, connect with nature, and appreciate the beauty that surrounds us. I find solace and inspiration in these moments, and I would be delighted to share them with someone special. Cooking is another passion of mine. I am a skilled chef who enjoys preparing delicious meals for myself and others. I love experimenting with flavors, creating unique dishes, and exploring different culinary traditions. The art of cooking brings people together and allows me to showcase my creativity and love through food. I am seeking a partner who shares my passion for life, embraces adventure, and appreciates the simple joys. Someone who enjoys leisurely walks, engaging conversations, and savoring good food. Let's embark on a journey together, exploring new destinations, creating culinary delights, and making beautiful memories.",
                Sex = "male",
                PreferSex = "female"
            },
            new Blank()
            {
                Id = Guid.NewGuid(),
                FirstName = "Maria",
                SecondName = "Deben",
                Years = 34,
                Photo = "/img/MariaDeben.jpg",
                Description = "Hi! My name is Maria, and I am a passionate jewelry designer who has a special talent for creating beautiful adornments. I am divorced and ready to explore new connections and possibilities in life. Designing and crafting jewelry is not just a profession for me; it is my creative outlet and a way to express myself. I love working with different materials, experimenting with unique designs, and bringing my ideas to life. The process of creating something beautiful from scratch is incredibly fulfilling and brings me joy. My favorite flowers are crocuses. These delicate and vibrant blooms are a symbol of renewal and beauty. I am captivated by their graceful appearance and the way they bloom early in the spring, bringing color and life to the surroundings. The sight of crocuses in full bloom never fails to lift my spirits and fill me with hope. I am looking to meet someone who appreciates creativity and values the importance of self-expression. Someone with a kind heart, who understands the complexities of life and is open to new beginnings. Let's explore the possibilities together, create meaningful connections, and embrace the beauty that life has to offer. ",
                Sex = "female",
                PreferSex = "male"
            },
            new Blank()
            {
                Id = Guid.NewGuid(),
                FirstName = "Lada",
                SecondName = "Kartish",
                Years = 21,
                Photo = "/img/LadaKartish.jpg",
                Description = "I am a successful businesswoman who values cleanliness, order, and a love for serious literature. As a businesswoman, I thrive in the world of entrepreneurship and professional development. I am driven, ambitious, and dedicated to my career. I find fulfillment in challenging myself and achieving my goals. Building my own enterprise has been an incredibly rewarding journey, and I am excited about the future possibilities it holds. Cleanliness and order are essential aspects of my life. I believe that an organized space promotes a clear mind and enhances productivity. I take pride in maintaining a tidy and well-structured environment, both at home and in my work surroundings. Keeping things in order brings a sense of calmness and clarity to my life. One of my greatest passions is a love for serious literature. I appreciate the depth, artistic expression, and thought-provoking nature of works from renowned authors. Reading allows me to explore different perspectives, broaden my knowledge, and indulge in the beauty of language. Whether it's classic literature, thought-provoking non-fiction, or contemporary novels, the world of books is a constant source of inspiration for me. I am seeking a like-minded individual who shares my passion for success, cleanliness, and literature. Someone who understands the importance of dedication, values organization, and appreciates the depth of meaningful books. Let's engage in stimulating conversations, explore literary treasures, and support each other's professional and personal growth. Together, we can create a harmonious and fulfilling life.",
                Sex = "female",
                PreferSex = "male"
            },
            new Blank()
            {
                Id = Guid.NewGuid(),
                FirstName = "Kristina",
                SecondName = "Brotova",
                Years = 31,
                Photo = "/img/KristinaBrotova.jpg",
                Description = "I have a passion for French cuisine, a love for the night sky and stars, and an appreciation for the beauty of red and white roses. I also work in a real estate agency. French cuisine holds a special place in my heart. The delicate flavors, rich history, and artistic presentation of French dishes captivate me. I enjoy exploring new recipes, experimenting with ingredients, and savoring the delicious creations that result. Cooking and sharing a delicious meal with loved ones is a true joy for me. One of my favorite pastimes is gazing at the night sky. There is something incredibly magical and awe-inspiring about the vastness of the universe and the countless stars twinkling above. Whether it's lying under the stars in a peaceful field or camping beneath a starry canopy, I find solace and inspiration in the night sky. I am also a romantic at heart, with a particular fondness for red and white roses. The vibrant red roses symbolize passion and love, while the pure white roses represent purity and beauty. These exquisite flowers never fail to create a sense of wonder and joy for me. Professionally, I work in a real estate agency. Helping people find their dream homes and guiding them through the process of buying or selling property brings me a great sense of satisfaction. I enjoy the challenges and rewards that come with working in this dynamic industry.",
                Sex = "female",
                PreferSex = "male"
            },
            new Blank()
            {
                Id = Guid.NewGuid(),
                FirstName = "Karolina",
                SecondName = "Smitova",
                Years = 27,
                Photo = "/img/KarolinaSmitova.jpg",
                Description = "I am a blogger, a travel enthusiast, and a music lover. I enjoy sharing my experiences and thoughts through my blog, where I write about my adventures, discoveries, and insights. Traveling is my greatest passion. Exploring new cultures, immersing myself in different landscapes, and meeting people from all walks of life fill me with joy and inspiration. Whether it's hiking in the mountains, strolling along the streets of a vibrant city, or relaxing on a pristine beach, I thrive on the thrill of discovering new places and embracing the beauty of the world. Music plays a significant role in my life. It has the power to transport me to different emotions, uplift my spirits, and bring people together. I have a diverse taste in music, ranging from soothing melodies to energetic beats. Attending concerts, music festivals, and discovering hidden gems in independent music scenes are some of my favorite activities. It would be wonderful to travel together, experiencing new destinations and creating lasting memories. I value deep conversations, intellectual curiosity, and a sense of humor. Let's explore the world, dance to the rhythm of life, and make beautiful music together.",
                Sex = "female",
                PreferSex = "male"
            },
            new Blank()
            {
                Id = Guid.NewGuid(),
                FirstName = "Irina",
                SecondName = "Nugeva",
                Years = 25,
                Photo = "/img/IrinaNugeva.jpg",
                Description = "Hello! My name is Irina, and I am an artist. My work is my passion and my creativity. I enjoy every moment spent with a canvas or a brush in my hand. My artworks reflect my inner world and the desire for beauty in all its manifestations. I am a true early bird. The sunrise is a magical time for me. I love feeling the first rays of the sun on my skin and savoring the silence and tranquility that exist in nature like nothing else. It is during this time that I find inspiration for my creations. You could say that I am a very versatile person. I love experimenting with different styles and art techniques. On one hand, I am an ordinary person with whom you can watch your favorite movie or have a coffee. On the other hand, I have a deep inner world that is reflected in my works. I appreciate cultural diversity and am always open to new and amazing adventures. My perfect date would be a picnic in nature. Climbing a hill, spreading out a picnic blanket, and enjoying delicious food and great company. I imagine us indulging in the beautiful scenery surrounding us and engaging in discussions about art, literature, or simply our inner world. The outdoor setting creates a special atmosphere and inspires me to create new ideas and concepts. If you share my passion for art, nature, and adventures, I would love to get to know you. Let's meet and create something beautiful together, whether it's on a canvas or in our shared lives.",
                Sex = "female",
                PreferSex = "male"
            },
            //удалить
            new Blank()
            {
                Id = User.BlankId,
                FirstName = "Anna",
                SecondName = "Andreikovets",
                Years = 18,
                Photo = "/img/AnnaAndreikovets_.jpg",
                Description = "Hello! I am studying to become a programmer. I absolutely adore bringing my creative ideas to life through coding, but I also have other passions that I love to share. I am a true talent in the kitchen and artistry! When I step into the kitchen, my imagination transforms simple ingredients into culinary magic. I enjoy experimenting with different cuisines and creating unique flavors. If you also have a passion for cooking, let's discover new recipes together and share our culinary adventures. Apart from cooking, I find inspiration in the world of art. With a brush in my hand and paint on the canvas, I create my own world. Drawing allows me to express emotions and showcase my inner beauty. I would love to find someone who shares my passion for art and can help bring new creative ideas to life. I am looking for someone who shares my passion for programming, cooking, and drawing. I want to find someone with whom I can not only discuss new technologies and code together but also spend time cooking delicious dishes and inspiring each other in our creative pursuits. If you are ambitious, creative, and eager to explore new horizons, I am looking forward to your response. Let's create a unique blend of programming, cooking, and artistry and become a source of inspiration for each other. I'll be happy to assist you if you have any further questions or need support. Just let me know!",
                Sex = "female",
                PreferSex = "male"
            }
        };
        static public List<Blank> Blanks { get { return blanks; } set { blanks.AddRange(value); } }

        static List<User> users = new List<User>()
        {
            new User()
            {
                Id = Guid.NewGuid(),
                BlankId = Blanks[0].Id,
                Email = "AlexandrMaksev@gmail.com",
                Password = "jytfvyff23ASD"
            },
            new User()
            {
                Id = Guid.NewGuid(),
                BlankId = Blanks[1].Id,
                Email = "AndreyKulkov@gmail.com",
                Password = "dgfkSMk34s"
            },
            new User()
            {
                Id = Guid.NewGuid(),
                BlankId = Blanks[2].Id,
                Email = "OlegSmishkev@gmail.com",
                Password = "gre34bgjhgSDFd"
            },
            new User()
            {
                Id = Guid.NewGuid(),
                BlankId = Blanks[3].Id,
                Email = "RonaldoEvrikan@gmail.com",
                Password = "hget4Sds345"
            },
            new User()
            {
                Id = Guid.NewGuid(),
                BlankId = Blanks[4].Id,
                Email = "VolodyaMartiskin@gmail.com",
                Password = "34SDFdvcf"
            },
            new User()
            {
                Id = Guid.NewGuid(),
                BlankId = Blanks[5].Id,
                Email = "MariaDeben@gmail.com",
                Password = "fg4zFdfGdgfdf"
            },
            new User()
            {
                Id = Guid.NewGuid(),
                BlankId = Blanks[6].Id,
                Email = "LadaKartish@gmail.com",
                Password = "hrey34546dfDFg"
            },
            new User()
            {
                Id = Guid.NewGuid(),
                BlankId = Blanks[7].Id,
                Email = "KristinaBrotova@gmail.com",
                Password = "gertg45SFdgfgd"
            },
            new User()
            {
                Id = Guid.NewGuid(),
                BlankId = Blanks[8].Id,
                Email = "KarolinaSmitova@gmail.com",
                Password = "klj;ukmhgA534f"
            },
            new User()
            {
                Id = Guid.NewGuid(),
                BlankId = Blanks[9].Id,
                Email = "IrinaNugeva@gmail.com",
                Password = "gfrioASDiu34"
            },
            //удалить
            User
        };
    
        static public List<User> Users { get { return users; } set { users.AddRange(value); } }
        
        static List<Attraction> attractions = new List<Attraction>(){
            new Attraction()
            {
                Id = Guid.NewGuid(),
                UserId = users[0].Id
            },
            new Attraction()
            {
                Id = Guid.NewGuid(),
                UserId = users[1].Id
            },
            new Attraction()
            {
                Id = Guid.NewGuid(),
                UserId = users[2].Id
            },
            new Attraction()
            {
                Id = Guid.NewGuid(),
                UserId = users[3].Id
            },
            new Attraction()
            {
                Id = Guid.NewGuid(),
                UserId = users[4].Id
            },
            new Attraction()
            {
                Id = Guid.NewGuid(),
                UserId = users[5].Id
            },
            new Attraction()
            {
                Id = Guid.NewGuid(),
                UserId = users[6].Id
            },
            new Attraction()
            {
                Id = Guid.NewGuid(),
                UserId = users[7].Id
            },
            new Attraction()
            {
                Id = Guid.NewGuid(),
                UserId = users[8].Id
            },
            new Attraction()
            {
                Id = Guid.NewGuid(),
                UserId = users[9].Id
            },
            //удалить
            new Attraction()
            {
                Id = Guid.NewGuid(),
                UserId = User.Id
            },
        };
        
        static public List<Attraction> Attractions { get { return attractions; } set { attractions.AddRange(value); } }
        static List<Interested> interesteds = new List<Interested>()
        {
            new Interested()
            {
                Id = Guid.NewGuid(),
                UserId = Users[0].Id
            },
            new Interested()
            {
                Id = Guid.NewGuid(),
                UserId = Users[1].Id
            },
            new Interested()
            {
                Id = Guid.NewGuid(),
                UserId = Users[2].Id
            },
            new Interested()
            {
                Id = Guid.NewGuid(),
                UserId = Users[3].Id
            },
            new Interested()
            {
                Id = Guid.NewGuid(),
                UserId = Users[4].Id
            },
            new Interested()
            {
                Id = Guid.NewGuid(),
                UserId = Users[5].Id
            },
            new Interested()
            {
                Id = Guid.NewGuid(),
                UserId = Users[6].Id
            },
            new Interested()
            {
                Id = Guid.NewGuid(),
                UserId = Users[7].Id
            },
            new Interested()
            {
                Id = Guid.NewGuid(),
                UserId = Users[8].Id
            },
            new Interested()
            {
                Id = Guid.NewGuid(),
                UserId = Users[9].Id
            },
            //удалить
            new Interested()
            {
                Id = Guid.NewGuid(),
                UserId = User.Id
            },
        };
        static public List<Interested> Interesteds { get { return interesteds; } set { interesteds.AddRange(value); } }
    }
}