using System;
using System.Numerics;

namespace kattis_collission_avoidance
{
    internal class CollisionAvoidance
    {
        static void Main(string[] args)
        {
            /*
             * mathematic calculations found at: https://studiofreya.com/3d-math-and-physics/little-more-advanced-collision-detection-spheres/
            Let us assume we have a vector between sphere centers (s), relative speed (v) and sum of radii (radiusSum):
            vecs = s1.pos - s2.pos
            vecv = s1.vel - s2.vel
            radiusSum = s1.radius + s2.radius
            We can calculate squared distance between centers. If the distance (dist) is negative, they already overlap:
            dist = vecs.dot(vecs)

            Spheres intersect if squared distance between centers is less than squared sum of radii:
            dist < radiusSum * radiusSum

            If b is 0.0 or positive, they are not moving towards each other:
            b = vecv.dot(vecs)
            a = vecv.dot(vecv)

            If d is negative, no real roots, and therefore no collisions:
            d = b*b - a*dist

            If we’ve come so far, we can calculate time of the collision:
            t = ( -b - sqrt{d}) / a
            */

            int numberOfTests = Convert.ToInt16(Console.ReadLine());

            for (int i = 0; i < numberOfTests; i++)
            {
                string inputVector1 = Console.ReadLine();
                string[] valuesVector1 = inputVector1.Split(new char[] { ' ' }, StringSplitOptions.None);

                string inputVector2 = Console.ReadLine();
                string[] valuesvector2 = inputVector2.Split(new char[] { ' ' }, StringSplitOptions.None);

                float x = float.Parse(valuesVector1[0]); // start position
                float y = float.Parse(valuesVector1[1]); // start position
                float z = float.Parse(valuesVector1[2]); // start position (in 3D)
                float r = float.Parse(valuesVector1[3]); // sphere radius
                float vx = float.Parse(valuesVector1[4]); // velocity
                float vy = float.Parse(valuesVector1[5]); // velocity
                float vz = float.Parse(valuesVector1[6]); // velocity (in 3D)

                float x2 = float.Parse(valuesvector2[0]); // start position
                float y2 = float.Parse(valuesvector2[1]); // start position
                float z2 = float.Parse(valuesvector2[2]); // start position (in 3D)
                float r2 = float.Parse(valuesvector2[3]); // sphere radius
                float vx2 = float.Parse(valuesvector2[4]); // velocity
                float vy2 = float.Parse(valuesvector2[5]); // velocity
                float vz2 = float.Parse(valuesvector2[6]); // velocity (in 3D)

                Vector3 positionSphere1 = new Vector3(x, y, z);
                Vector3 positionSphere2 = new Vector3(x2, y2, z2);
                Vector3 velocitySphere1 = new Vector3(vx, vy, vz);
                Vector3 velocitySphere2 = new Vector3(vx2, vy2, vz2);

                Vector3 distanceBetweenSphereCentres = positionSphere1 - positionSphere2;
                Vector3 differenceInVelocity = velocitySphere1 - velocitySphere2;
                float radiusSum = r + r2;
                float distance = Vector3.Dot(distanceBetweenSphereCentres, distanceBetweenSphereCentres) - (radiusSum * radiusSum);

                double a = Vector3.Dot(differenceInVelocity, differenceInVelocity);
                double b = Vector3.Dot(differenceInVelocity, distanceBetweenSphereCentres);
                double d = b * b - a * distance;

                if (b >= 0 || d < 0)
                {
                    Console.WriteLine("No collision");
                    continue;
                }

                double timeOfCollision = (-b - Math.Sqrt(d)) / a;

                Console.WriteLine(Math.Round(timeOfCollision, 3));

            }
        }
    }
}
